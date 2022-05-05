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
        /// Endpoint para buscar um usu�rio pelo ID
        /// </summary>
        /// <param name="id">ID do usu�rio que ser� buscado</param>
        /// <returns>Retorna usu�rio buscado</returns>
        [HttpGet("BuscarUsuario/{id}")]
        public IActionResult BuscarUsuario(int id)
        {
            try
            {
                //Caso o ID seja maior que 0
                if (id > 0)
                {
                    //Busca o usu�rio pelo ID
                    Usuario usuario = _usuarioRepository.BuscarUsuario(id);
                    //Caso n�o haja um usu�rio com o mesmo ID
                    if(usuario == null) 
                        //Retorna NotFound
                        return NotFound(new
                        {
                            Mensagem = "O ID n�o corresponde a nenhum funcion�rio"
                        });
                    //Caso haja, retorna o usu�rio
                    return Ok(usuario);
                }
                return BadRequest(new
                {
                    Mensagem = "Id informado � inv�lido"
                });
            }
            catch (Exception ex)
            {

                throw;
            }
            
        }

        /// <summary>
        /// Endpoint para buscar o usu�rio logado
        /// </summary>
        /// <returns>O usu�rio que est� logado</returns>
        [Authorize]
        [HttpGet("BuscarUsuario")]
        public IActionResult BuscarUsuarioLogado()
        {
            try
            {
                //Recebe o ID do usu�rio logado
                int id = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Jti).Value);
                //Caso o ID seja maior que 0
                if (id > 0)
                {
                    //Busca o usu�rio pelo ID
                    Usuario usuario = _usuarioRepository.BuscarUsuario(id);
                    //Caso n�o haja um usu�rio com o mesmo ID
                    if (usuario == null)
                        //Retorna NotFound
                        return NotFound(new
                        {
                            Mensagem = "O ID n�o corresponde a nenhum funcion�rio"
                        });
                    //Caso haja, retorna o usu�rio
                    return Ok(usuario);
                }
                return BadRequest(new
                {
                    Mensagem = "Id informado � inv�lido"
                });
            }
            catch (Exception ex)
            {

                throw;
            }

        }

        /// <summary>
        /// Endpoint que lista todos os funcion�rios 
        /// </summary>
        /// <returns>Lista de Uus�rios</returns>
        [HttpGet("Funcionarios")]
        public IActionResult ListarFuncionarios()
        {
            try
            {
                //Inst�ncia uma lista de usu�rios e preenche com funcionarios
                List<Usuario> lista = _usuarioRepository.ListarFuncionarios();

                if (lista == null)
                    return NotFound(new
                    {
                        Mensagem = "N�o h� funcion�ros no sistema"
                    });
                return Ok(lista);
            }
            catch (Exception ex)
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
                    Mensagem = "Os dados inseridos s�o inv�lidos!"
                });
            }
            catch (Exception ex)
            {

                throw;
                return BadRequest(ex);
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
                    Mensagem = "C�digo enviado"
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
                    Mensagem = "Os dados inseridos s�o inv�lidos!"
                });
            }
            catch (Exception ex)
            {

                throw;
                return BadRequest(ex);
            }
        }
    }
}
