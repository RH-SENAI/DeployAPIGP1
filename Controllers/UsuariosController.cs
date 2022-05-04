using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;

namespace SenaiRH_G1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuariosController(IUsuarioRepository repo)
        {
            _usuarioRepository = repo;
        }

        /// <summary>
        /// Endpoint para buscar um usuario pelo ID
        /// </summary>
        /// <param name="id">ID do usuario que sera buscado</param>
        /// <returns>Retorna usuario buscado</returns>
        [HttpGet("BuscarUsuario/{id}")]
        public IActionResult BuscarUsuario(int id)
        {
            try
            {
                //Caso o ID seja maior que 0
                if (id > 0)
                {
                    //Busca o usuário pelo ID
                    Usuario usuario = _usuarioRepository.BuscarUsuario(id);
                    //Caso nao haja um usuario com o mesmo ID
                    if(usuario == null) 
                        //Retorna NotFound
                        return NotFound(new
                        {
                            Mensagem = "O ID não corresponde a nenhum funcionário"
                        });
                    //Caso haja, retorna o usuario
                    return Ok(usuario);
                }
                return BadRequest(new
                {
                    Mensagem = "Id informado é inválido"
                });
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        /// <summary>
        /// Endpoint para buscar o usuario logado
        /// </summary>
        /// <returns>O usuário que esta logado</returns>
        [Authorize]
        [HttpGet("BuscarUsuario")]
        public IActionResult BuscarUsuarioLogado()
        {
            try
            {
                //Recebe o ID do usuario logado
                int id = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Jti).Value);
                //Caso o ID seja maior que 0
                if (id > 0)
                {
                    //Busca o usuario pelo ID
                    Usuario usuario = _usuarioRepository.BuscarUsuario(id);
                    //Caso nao haja um usuario com o mesmo ID
                    if (usuario == null)
                        //Retorna NotFound
                        return NotFound(new
                        {
                            Mensagem = "O ID não corresponde a nenhum funcionário"
                        });
                    //Caso haja, retorna o usuario
                    return Ok(usuario);
                }
                return BadRequest(new
                {
                    Mensagem = "Id informado é inválido"
                });
            }
            catch (Exception)
            {

                throw;
            }

        }

        /// <summary>
        /// Endpoint que lista todos os funcionarios 
        /// </summary>
        /// <returns>Lista de Usuarios</returns>
        [HttpGet("Funcionarios")]
        public IActionResult ListarFuncionarios()
        {
            try
            {
                //Instância uma lista de usuarios e preenche com funcionarios
                List<Usuario> lista = _usuarioRepository.ListarFuncionarios();

                if (lista == null)
                    return NotFound(new
                    {
                        Mensagem = "Não há funcionáros no sistema"
                    });
                return Ok(lista);
            }
            catch (Exception)
            {

                throw;
            }
            
        }

        
        [HttpPost("VerificaSenha/{idUsuario}")]
        public IActionResult VerificaSenha(int idUsuario)
        {
            try
            {
                string senhaAtual = Request.Headers["senhaUser"].ToString();
                bool resposta = _usuarioRepository.VerificaSenha(senhaAtual, idUsuario);
                if (resposta == true)
                {
                    return Ok(new
                    {
                        Mensagem = resposta
                    });
                }
                return BadRequest(new
                {
                    Mensagem = resposta
                });
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPatch("AlteraSenha/{idUsuario}")]
        public IActionResult AlterarSenha(int idUsuario)
        {
            try
            {
                string senhaAtual = Request.Headers["senhaUser"].ToString();
                string senhaNova = Request.Headers["senhaNova"].ToString();
                string senhaConfirmacao = Request.Headers["senhaConfirmacao"].ToString();

                if (idUsuario > 0 && senhaNova != null && senhaAtual != null && senhaConfirmacao != null)
                {
                    _usuarioRepository.AlterarSenha(idUsuario, senhaNova, senhaAtual, senhaConfirmacao);

                    return Ok(new
                    {
                        Mensagem = "A senha foi alterada"
                    });
                }
                return BadRequest(new
                {
                    Mensagem = "Os dados inseridos são inválidos!"
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
                throw;
            }
        }

        [HttpPost("RecuperarSenhaEnviar/{email}")]
        public IActionResult EnviaEmail(string email)
        {
            try
            {
                _usuarioRepository.EnviaEmailRecSenha(email);
                return Ok(new
                {
                    Mensagem = "Código enviado"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }

        [HttpPost("RecuperarSenhaVerifica/{codigo}")]
        public IActionResult VerificaSenhaRec(int codigo)
        {
            try
            {
                if (_usuarioRepository.VerificaRecSenha(codigo))
                {
                    return Ok();
                }
                return BadRequest();

            }
            catch (Exception)
            {

                throw;
            }
        }
        [HttpPatch("AlteraSenhaRec/{email}")]
        public IActionResult AlterarSenhaRec(string email)
        {
            try
            {
                string senhaNova = Request.Headers["senhaNova"].ToString();
                string senhaConfirmacao = Request.Headers["senhaConfirmacao"].ToString();

                if (email != null && senhaNova != null && senhaConfirmacao != null)
                {
                    _usuarioRepository.AlterarSenhaRec(email, senhaNova, senhaConfirmacao);

                    return Ok(new
                    {
                        Mensagem = "A senha foi alterada"
                    });
                }
                return BadRequest(new
                {
                    Mensagem = "Os dados inseridos são inválidos!"
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
                throw;
            }
        }

        [HttpGet("Ranking")]
        public IActionResult Ranking()
        {
            try
            {
                return Ok(_usuarioRepository.Ranking());
                
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }
    }
}
