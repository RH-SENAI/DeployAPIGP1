using SenaiRH_G1.Contexts;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using SenaiRH_G1.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using SenaiRH_G1.ViewModel;

namespace SenaiRH_G1.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly senaiRhContext ctx;
        private static int randomCode;

        public UsuarioRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }

        /// <summary>
        /// Método para Buscar um usuário
        /// </summary>
        /// <param name="id">ID do Usuário que será buscado</param>
        /// <returns>O usuário buscado</returns>
        public Usuario BuscarUsuario(int id)
        {
            //Instancia novo usuario
            Usuario usuario = new ();
            //Busca o usuário pelo ID fornecido, salva no usuario instânciado e retorna o usuário
            return usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        /// <summary>
        /// Método para listar todos os funcionarios
        /// </summary>
        /// <returns>Retorna todos os funcionários cadastrados</returns>
        public List<FuncionariosViewModel> ListarFuncionarios(int idGestor)
        {
            //Busca todos os usuários do sistema que
           /*return ctx.Usuarios
                //IdTipoUsuario seja igual ao de funcionario
                .Where(u => u.IdTipoUsuario == 1)
                //Seleciona os dados que serão enviados na resposta
                .Select(u => new Usuario()
                {
                    IdUsuario = u.IdUsuario,
                    Nome = u.Nome,
                    Email = u.Email,
                    DataNascimento = u.DataNascimento,
                    SaldoMoeda = u.SaldoMoeda,
                    Trofeus = u.Trofeus,
                    IdUnidadeSenai = u.IdUnidadeSenai,
                    IdUnidadeSenaiNavigation = new Unidadesenai()
                    {
                        NomeUnidadeSenai = u.IdUnidadeSenaiNavigation.NomeUnidadeSenai,
                        TelefoneUnidadeSenai = u.IdUnidadeSenaiNavigation.TelefoneUnidadeSenai,
                        EmailUnidadeSenai = u.IdUnidadeSenaiNavigation.EmailUnidadeSenai
                    },
                    IdCargoNavigation = new Cargo()
                    {
                        NomeCargo = u.IdCargoNavigation.NomeCargo,
                        IdCargo = u.IdCargoNavigation.IdCargo
                    }
                }).ToList();*/

               var listaFuncionarios = from usuario in ctx.Usuarios                                     
                                       join lotacaos in ctx.Lotacaos on usuario.IdUsuario equals lotacaos.IdFuncionario
                                       join grupos  in ctx.Grupos on lotacaos.IdGrupo equals grupos.IdGrupo
                                       where grupos.IdGestor == idGestor
                                       select new FuncionariosViewModel
                                       {
                                           IdUsuario = usuario.IdUsuario,
                                           Nome = usuario.Nome,
                                           Latitude = usuario.Latitude,
                                           Longitude = usuario.Longitude,
                                           Cpf = usuario.Cpf,
                                           Email = usuario.Email,
                                           DataNascimento = usuario.DataNascimento,
                                           SaldoMoeda = usuario.SaldoMoeda,
                                           Trofeus = usuario.Trofeus,
                                           CaminhoFotoPerfil = usuario.CaminhoFotoPerfil

                                       };
            return listaFuncionarios.ToList();
        }

        /// <summary>
        /// Método para fazer login no sistema
        /// </summary>
        /// <param name="Cpf">CPF do usuário que será logado</param>
        /// <param name="senha">senha do usuário que será logado</param>
        /// <returns>Usuario</returns>
        public Usuario Login(string Cpf, string senha)
        {
            //Busca usuário pelo email
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Cpf == Cpf);

            //Caso o usuário seja válido
            if (usuario != null)
            {
                //Verifica se a senha do usuário cadastrado no banco de dados é uma hash

                //Caso não seja uma Hash
                if (usuario.Senha.Length != 60 && usuario.Senha[0].ToString() != "$")
                {
                    //Verifica se a senha digitada é correta
                    //Caso seja correta
                    if (senha == usuario.Senha)
                    {
                        
                        //Gera uma Hash com a senha do usuario
                        string senhaHash = Criptografia.GerarHash(usuario.Senha);
                        //Altera a senha no banco de dados
                        usuario.Senha = senhaHash;
                        //Salva a alteração
                        ctx.Usuarios.Update(usuario);
                        ctx.SaveChanges();
                        //Retorna o usuário
                        return usuario;
                    }
                    //Caso seja incorreta
                    else
                    {
                        //Retorna nulo
                        return null;
                    }
                }
                //Caso seja uma Hash, Compara as senha e compara as senha
                bool confere = Criptografia.CompararSenha(senha, usuario.Senha);
                //Caso sejam compatíveis
                if (confere)
                    //Retorna o Usuário
                    return usuario;
            }
            //Caso não seja válido, retorna nulo
            return null;
        }

        public void AlterarSenha(int idUsuario, string senhaNova, string senhaAtual, string senhaConfirmacao)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
            if (usuario != null)
            {
                if (BCrypt.Net.BCrypt.Verify(senhaAtual, usuario.Senha))
                {
                    if (senhaNova == senhaConfirmacao)
                    {
                        string novaSenhaHash = BCrypt.Net.BCrypt.HashPassword(senhaNova);
                        usuario.Senha = novaSenhaHash;
                        usuario.UsuarioAtivo = true;
                        ctx.Usuarios.Update(usuario);
                        ctx.SaveChanges();
                    }
                    
                }
                
            }
        }

        public void AlterarSenhaRec(string email, string senhaNova, string senhaConfirmacao)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Email == email);
            if (usuario != null)
            {
                
                    if (senhaNova == senhaConfirmacao)
                    {
                        string novaSenhaHash = BCrypt.Net.BCrypt.HashPassword(senhaNova);
                        usuario.Senha = novaSenhaHash;
                        usuario.UsuarioAtivo = true;
                        ctx.Usuarios.Update(usuario);
                        ctx.SaveChanges();
                    }
            }
        }

        public bool VerificaSenha(string senha, int idUsuario)
        {
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

            if (BCrypt.Net.BCrypt.Verify(senha, usuario.Senha))
            {
                return true;
            }
            return false;
        }

        public void EnviaEmailRecSenha(string email)
        {
            Random rand = new Random();
            int code = rand.Next(99999);

            Usuario user = ctx.Usuarios.FirstOrDefault(u => u.Email == email);

            if (user != null)
            {
                MimeMessage message = new MimeMessage();
                message.From.Add(new MailboxAddress("SenaiRHTeste", "senairhteste@gmail.com"));
                message.To.Add(MailboxAddress.Parse(user.Email));
                message.Subject = "Teste email";
                message.Body = new TextPart("plain")
                {
                    Text = @"Seu código de recuperação de senha é: " + code
                };

                SmtpClient client = new SmtpClient();

                try
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate("senairhteste@gmail.com", "SesiSenai@132");
                    client.Send(message);
                }
                catch (Exception)
                {

                    throw;
                }
                finally
                {
                    client.Disconnect(true);
                    client.Dispose();
                    randomCode = code;
                }
            }
        }

        public bool VerificaRecSenha(int codigo)
        {
            if (codigo > 0)
            {
                if (codigo == randomCode)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public List<FuncionariosViewModel> Ranking(int idGestor)
        {
             

            var listaFuncionarios = from usuario in ctx.Usuarios
                                    join lotacaos in ctx.Lotacaos on usuario.IdUsuario equals lotacaos.IdFuncionario
                                    join grupos in ctx.Grupos on lotacaos.IdGrupo equals grupos.IdGrupo
                                    where grupos.IdGestor == idGestor
                                    orderby usuario.Trofeus descending
                                    select new FuncionariosViewModel
                                    {
                                        IdUsuario = usuario.IdUsuario,
                                        Nome = usuario.Nome,
                                        Latitude = usuario.Latitude,
                                        Longitude = usuario.Longitude,
                                        Cpf = usuario.Cpf,
                                        Email = usuario.Email,
                                        DataNascimento = usuario.DataNascimento,
                                        SaldoMoeda = usuario.SaldoMoeda,
                                        Trofeus = usuario.Trofeus,
                                        CaminhoFotoPerfil = usuario.CaminhoFotoPerfil

                                    };

            return listaFuncionarios.ToList();
        }

        public List<FuncionariosViewModel> RankingMobile()
        {


            var listaFuncionarios = from usuario in ctx.Usuarios
                                    join lotacaos in ctx.Lotacaos on usuario.IdUsuario equals lotacaos.IdFuncionario
                                    join grupos in ctx.Grupos on lotacaos.IdGrupo equals grupos.IdGrupo
                                    orderby usuario.Trofeus descending
                                    select new FuncionariosViewModel
                                    {
                                        IdUsuario = usuario.IdUsuario,
                                        Nome = usuario.Nome,
                                        Latitude = usuario.Latitude,
                                        Longitude = usuario.Longitude,
                                        Cpf = usuario.Cpf,
                                        Email = usuario.Email,
                                        DataNascimento = usuario.DataNascimento,
                                        SaldoMoeda = usuario.SaldoMoeda,
                                        Trofeus = usuario.Trofeus,
                                        CaminhoFotoPerfil = usuario.CaminhoFotoPerfil

                                    };

            return listaFuncionarios.ToList();
        }
    }
}
