using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using SenaiRH_G1.Contexts;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using SenaiRH_G1.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SenaiRH_G1.Repositories
{
    public class AtividadeRepository : IAtividadeRepository
    {
        private readonly senaiRhContext ctx;
        public AtividadeRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        /// <summary>
        /// Método para associar um usuário à uma atividade
        /// </summary>
        /// <param name="idUsuario">ID do usuário que será associado à atividade</param>
        /// <param name="idAtividade">ID da atividade a qual o usuário será associado</param>
        public void AssociarAtividade(int idUsuario, int idAtividade)
        {
            //Criando nova associação de usuáro com atividade
            Minhasatividade novaAssociacao = new Minhasatividade();

            //Buscando as entidades por meio dos ID's fornecidos
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            Atividade atividade = ctx.Atividades.FirstOrDefault(u => u.IdAtividade == idAtividade);
            Cargo cargo = ctx.Cargos.FirstOrDefault(u => u.IdCargo == usuario.IdCargo);

            //Verifica se a atividade e se o usuário fornecidos são validos 
            if (atividade != null && usuario != null)
            {
                //Atribui os dados à nova associação
                novaAssociacao.IdUsuario = idUsuario;
                novaAssociacao.IdAtividade = idAtividade;
                novaAssociacao.IdSetor = cargo.IdSetor;
                //Situação da atividade passa a ser "Em produção"
                novaAssociacao.IdSituacaoAtividade = 3;

                //Cadastra nova associação no banco de dados
                ctx.Minhasatividades.Add(novaAssociacao);
                ctx.SaveChanges();
            }

           
        }

        public Atividade BuscarPorId(int id)
        {
            return ctx.Atividades.FirstOrDefault(c => c.IdAtividade == id);
        }

        public void CadastrarAtividade(Atividade atividade)
        {
            if (atividade.NomeAtividade != null || atividade.RecompensaTrofeu != 0 || atividade.RecompensaMoeda != 0)
            {
                ctx.Atividades.Add(atividade);
                ctx.SaveChangesAsync();
            }
        }

        /// <summary>
        /// Método para listar as atividades atribuídas ao usuário
        /// </summary>
        /// <param name="id">ID do usuário que terá suas atividades listadas</param>
        /// <returns>Lista de atividades</returns>
        public List<MinhasAtividadesViewModel> ListarMinhas(int id)
        {
            //Query que busca as atividades associadas ao usuário
            var listaMinhasAtividade = from atividades in ctx.Atividades
                                       join minhasAtividades in ctx.Minhasatividades on atividades.IdAtividade equals minhasAtividades.IdAtividade
                                       where minhasAtividades.IdUsuario == id
                                       select new MinhasAtividadesViewModel
                                       {
                                           IdAtividade = atividades.IdAtividade,
                                           NomeAtividade = atividades.NomeAtividade,
                                           DataInicio = atividades.DataInicio,
                                           DataCriacao = atividades.DataCriacao,
                                           DataConclusao = atividades.DataConclusao,
                                           DescricaoAtividade = atividades.DescricaoAtividade,
                                           RecompensaMoeda = atividades.RecompensaMoeda,
                                           RecompensaTrofeu = atividades.RecompensaTrofeu,
                                           NecessarioValidar = atividades.NecessarioValidar,
                                           IdMinhasAtividades = minhasAtividades.IdMinhasAtividades,
                                           IdSetor = minhasAtividades.IdSetor,
                                           IdUsuario = minhasAtividades.IdUsuario,
                                           IdSituacaoAtividade = minhasAtividades.IdSituacaoAtividade
                                       };
                                       

            return listaMinhasAtividade.ToList();

        }

        public List<Atividade> ListarTodas()
        {
            return ctx.Atividades
                .Select(a => new Atividade()
                {
                    IdAtividade = a.IdAtividade,
                    NomeAtividade = a.NomeAtividade,
                    DataInicio = a.DataInicio,
                    DataConclusao = a.DataConclusao,
                    RecompensaMoeda = a.RecompensaMoeda,
                    RecompensaTrofeu = a.RecompensaTrofeu,
                    DescricaoAtividade = a.DescricaoAtividade,
                    NecessarioValidar = a.NecessarioValidar,
                    DataCriacao = a.DataCriacao,
                    IdGestorCadastroNavigation = new Usuario()
                    {
                        Nome = a.IdGestorCadastroNavigation.Nome
                    }
                })
                .ToList();
        }

        public List<MinhasAtividadesViewModel> ListaValidar()
        {
            var listaMinhasAtividade = from atividades in ctx.Atividades
                                       join minhasAtividades in ctx.Minhasatividades on atividades.IdAtividade equals minhasAtividades.IdAtividade
                                       where minhasAtividades.IdSituacaoAtividade == 2
                                       select new MinhasAtividadesViewModel
                                       {
                                           IdAtividade = atividades.IdAtividade,
                                           NomeAtividade = atividades.NomeAtividade,
                                           DataInicio = atividades.DataInicio,
                                           DataCriacao = atividades.DataCriacao,
                                           DataConclusao = atividades.DataConclusao,
                                           DescricaoAtividade = atividades.DescricaoAtividade,
                                           RecompensaMoeda = atividades.RecompensaMoeda,
                                           RecompensaTrofeu = atividades.RecompensaTrofeu,
                                           NecessarioValidar = atividades.NecessarioValidar,
                                           IdMinhasAtividades = minhasAtividades.IdMinhasAtividades,
                                           IdSetor = minhasAtividades.IdSetor,
                                           IdUsuario = minhasAtividades.IdUsuario,
                                           IdSituacaoAtividade = minhasAtividades.IdSituacaoAtividade
                                       };


            return listaMinhasAtividade.ToList();
        }

        public void RemoverAtividade(Atividade atividade)
        {
            ctx.Atividades.Remove(atividade);
            ctx.SaveChangesAsync();
        }

        /// <summary>
        /// Método para finalizar uma atividade em curso
        /// </summary>
        /// <param name="idUsuario">ID do usuário que terá sua atividade finalizada</param>
        /// <param name="idAtividade">ID da atividade que será finalizada</param>
        public void FinalizarAtividade(int idUsuario, int idAtividade)
        {
            //Buscando as entidades por meio dos ID's fornecidos
            Minhasatividade minhaAtividade = ctx.Minhasatividades.FirstOrDefault(a => a.IdAtividade == idAtividade && a.IdUsuario == idUsuario);
            Atividade atividade = ctx.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            //Verificação se existe a relação entre usuário e atividade
            if (minhaAtividade != null)
            {
                //Verifica se a atividade necessita de validação para ser finalizada
                if(atividade.NecessarioValidar)
                {
                    //Caso necessário, a situação da atividade será alterada para "Aguardando validação"
                    minhaAtividade.IdSituacaoAtividade = 2;
                    ctx.Minhasatividades.Update(minhaAtividade);
                    ctx.SaveChanges();
                }
                else
                {
                    //Caso contrário, a situação da atividade será alterada para "Finalizada" e as recompensas da atividade serão atribuídas ao usuário
                    minhaAtividade.IdSituacaoAtividade = 1;
                    usuario.SaldoMoeda = usuario.SaldoMoeda + atividade.RecompensaMoeda;
                    usuario.Trofeus = usuario.Trofeus + atividade.RecompensaTrofeu;
                    ctx.Minhasatividades.Update(minhaAtividade);
                    ctx.Usuarios.Update(usuario);
                    ctx.SaveChanges();
                }

            }
            
        }

        /// <summary>
        /// Método para validar uma atividade que está aguardando validação do administrador
        /// </summary>
        /// <param name="idAtividade">ID da atividade que será validada</param>
        /// <param name="idUsuario">ID do usuário que terá sua atividade validada</param>
        public void ValidarAtividade(int idAtividade, int idUsuario)
        {
            //Buscando as entidades por meio dos ID's fornecidos
            Minhasatividade minhaAtividade = ctx.Minhasatividades.FirstOrDefault(a => a.IdAtividade == idAtividade && a.IdUsuario == idUsuario);
            Atividade atividade = ctx.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            //Verificação se existe a relação entre usuário e atividade
            if (minhaAtividade != null)
            {
                //Verifica se a situação da atividade é igual à "Aguardando validação"
                if(minhaAtividade.IdSituacaoAtividade == 2)
                {
                    //Caso seja, a atividade terá sua situação trocada para "Finalizada" e as recompensas serão atribuídas ao usuário.
                    minhaAtividade.IdSituacaoAtividade = 1;
                    usuario.SaldoMoeda = usuario.SaldoMoeda + atividade.RecompensaMoeda;
                    usuario.Trofeus = usuario.Trofeus + atividade.RecompensaTrofeu;
                    ctx.Usuarios.Update(usuario);
                    ctx.Minhasatividades.Update(minhaAtividade);
                    ctx.SaveChanges();
                }
            }
        }
    }
}
