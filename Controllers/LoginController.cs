using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using SenaiRH_G1.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SenaiRH_G1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController(IUsuarioRepository repo)
        {
            _usuarioRepository = repo;
        }

        /// <summary>
        /// Valida o Usuário
        /// </summary>
        /// <param name="login">Informações de login do usuário</param>
        /// <returns>O token do usuário logado</returns>
        [HttpPost]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Usuario usuarioBuscado = _usuarioRepository.Login(login.Cpf, login.senha);

                if (usuarioBuscado == null)
                {
                    return BadRequest(new
                    {
                        mensagem = "CPF ou senha inváidos!"
                    });
                }

                // Caso o usuário seja encontrado, prossegue para a criação do token

                /*
                    Dependências
                    Criar e validar o JWT:      System.IdentityModel.Tokens.Jwt
                    Integrar a autenticação:    Microsoft.AspNetCore.Authentication.JwtBearer (versão compatível com o .NET do projeto)
                */

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, usuarioBuscado.IdUsuario.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name, usuarioBuscado.Nome),
                    new Claim(ClaimTypes.Role, usuarioBuscado.IdTipoUsuario.ToString()),
                    new Claim("isActive", usuarioBuscado.UsuarioAtivo.ToString()),
                    new Claim("role", usuarioBuscado.IdTipoUsuario.ToString()),
                    new Claim("foto", usuarioBuscado.CaminhoFotoPerfil.ToString())
                    ///new Claim("nivelSatisfa", usuarioBuscado.NivelSatisfacao.ToString())
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("senairh-autenticacao-token"));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                var meuToken = new JwtSecurityToken
                    (
                        issuer: "SenaiRH_G1.WebApi",
                        audience: "SenaiRH_G1.WebApi",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
