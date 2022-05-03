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
        /// Metodo para Buscar um usuário
        /// </summary>
        /// <param name="id">ID do Usuário que sera buscado</param>
        /// <returns>O usuario buscado</returns>
        public Usuario BuscarUsuario(int id)
        {
            //Instancia novo usuario
            Usuario usuario = new ();
            //Busca o usuario pelo ID fornecido, salva no usuario instanciado e retorna o usuário
            return usuario = ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == id);
        }

        /// <summary>
        /// Metodo para listar todos os funcionarios
        /// </summary>
        /// <returns>Retorna todos os funcionários cadastrados</returns>
        public List<Usuario> ListarFuncionarios()
        {
            //Busca todos os usuarios do sistema que
           return ctx.Usuarios
                //IdTipoUsuario seja igual ao de funcionario
                .Where(u => u.IdTipoUsuario == 1)
                //Seleciona os dados que serao enviados na resposta
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
                    }
                }).ToList();
        }

        /// <summary>
        /// Metodo para fazer login no sistema
        /// </summary>
        /// <param name="Cpf">CPF do usuário que sera logado</param>
        /// <param name="senha">senha do usuário que sera logado</param>
        /// <returns>Usuario</returns>
        public Usuario Login(string Cpf, string senha)
        {
            //Busca usuario pelo email
            var usuario = ctx.Usuarios.FirstOrDefault(u => u.Cpf == Cpf);

            //Caso o usuario seja valido
            if (usuario != null)
            {
                //Verifica se a senha do usuario cadastrado no banco de dados a uma hash

                //Caso nao seja uma Hash
                if (usuario.Senha.Length != 60 && usuario.Senha[0].ToString() != "$")
                {
                    //Verifica se a senha digitada e correta
                    //Caso seja correta
                    if (senha == usuario.Senha)
                    {
                        
                        //Gera uma Hash com a senha do usuario
                        string senhaHash = Criptografia.GerarHash(usuario.Senha);
                        //Altera a senha no banco de dados
                        usuario.Senha = senhaHash;
                        //Salva a alteracao
                        ctx.Usuarios.Update(usuario);
                        ctx.SaveChanges();
                        //Retorna o usuario
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
                //Caso sejam compativeis
                if (confere)
                    //Retorna o Usuário
                    return usuario;
            }
            //Caso nao seja valido, retorna nulo
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
                message.From.Add(new MailboxAddress(user.Nome, user.Email));
                message.To.Add(MailboxAddress.Parse(user.Email));
                message.Subject = "Teste email";
                message.Body = new TextPart("plain")
                {
                    Text = @"Seu código de recuperar senha é: " + code
                };

                SmtpClient client = new SmtpClient();

                try
                {
                    client.Connect("smtp.gmail.com", 465, true);
                    client.Authenticate(user.Email, "SesiSenai@132");
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
    }
}
