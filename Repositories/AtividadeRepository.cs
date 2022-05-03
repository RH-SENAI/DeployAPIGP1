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
        /// Metodo para associar um usuario a uma atividade
        /// </summary>
        /// <param name="idUsuario">ID do usuario que sera associado a atividade</param>
        /// <param name="idAtividade">ID da atividade a qual o usuario sera associado</param>
        public void AssociarAtividade(int idUsuario, int idAtividade)
        {
            //Criando nova associacao de usuario com atividade
            Minhasatividade novaAssociacao = new Minhasatividade();

            //Buscando as entidades por meio dos IDs fornecidos
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            Atividade atividade = ctx.Atividades.FirstOrDefault(u => u.IdAtividade == idAtividade);
            Cargo cargo = ctx.Cargos.FirstOrDefault(u => u.IdCargo == usuario.IdCargo);

            //Verifica se a atividade e se o usuario fornecidos sao validos 
            if (atividade != null && usuario != null)
            {
                //Atribui os dados a nova associação
                novaAssociacao.IdUsuario = idUsuario;
                novaAssociacao.IdAtividade = idAtividade;
                novaAssociacao.IdSetor = cargo.IdSetor;
                //Situação da atividade passa a ser em produção
                novaAssociacao.IdSituacaoAtividade = 3;

                //Cadastra nova associacao no banco de dados
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
        /// Metodo para listar as atividades atribuidas ao usuario
        /// </summary>
        /// <param name="id">ID do usuario que tera suas atividades listadas</param>
        /// <returns>Lista de atividades</returns>
        public List<MinhasAtividadesViewModel> ListarMinhas(int id)
        {
            //Query que busca as atividades associadas ao usuario
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
            return ctx.Atividades.ToList();
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
        /// Metodo para finalizar uma atividade em curso
        /// </summary>
        /// <param name="idUsuario">ID do usuario que tera sua atividade finalizada</param>
        /// <param name="idAtividade">ID da atividade que sera finalizada</param>
        public void FinalizarAtividade(int idUsuario, int idAtividade)
        {
            //Buscando as entidades por meio dos IDs fornecidos
            Minhasatividade minhaAtividade = ctx.Minhasatividades.FirstOrDefault(a => a.IdAtividade == idAtividade && a.IdUsuario == idUsuario);
            Atividade atividade = ctx.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            //Verificacaoo se existe a relacao entre usuario e atividade
            if (minhaAtividade != null)
            {
                //Verifica se a atividade necessita de validacao para ser finalizada
                if(atividade.NecessarioValidar)
                {
                    //Caso necessario, a situacao da atividade sera alterada para Aguardando validacao
                    minhaAtividade.IdSituacaoAtividade = 2;
                    ctx.Minhasatividades.Update(minhaAtividade);
                    ctx.SaveChanges();
                }
                else
                {
                    //Caso contrario, a situacao da atividade sera alterada para Finalizada e as recompensas da atividade serao atribuidas ao usuario
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
        /// Metodo para validar uma atividade que esta aguardando valicao do administrador
        /// </summary>
        /// <param name="idAtividade">ID da atividade que sera validada</param>
        /// <param name="idUsuario">ID do usuário que tera sua atividade validada</param>
        public void ValidarAtividade(int idAtividade, int idUsuario)
        {
            //Buscando as entidades por meio dos IDs fornecidos
            Minhasatividade minhaAtividade = ctx.Minhasatividades.FirstOrDefault(a => a.IdAtividade == idAtividade && a.IdUsuario == idUsuario);
            Atividade atividade = ctx.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);
            Usuario usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            //Verificação se existe a relacao entre usuario e atividade
            if (minhaAtividade != null)
            {
                //Verifica se a situacao da atividade a igual a Aguardando validacao
                if(minhaAtividade.IdSituacaoAtividade == 2)
                {
                    //Caso seja, a atividade tera sua situação trocada para Finalizada e as recompensas serao atribuidas ao usuario.
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
