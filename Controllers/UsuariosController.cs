using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using SenaiRH_G1.ViewModel;
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
        /// Endpoint para buscar um usuário pelo ID
        /// </summary>
        /// <param name="id">ID do usuário que será buscado</param>
        /// <returns>Retorna usuário buscado</returns>
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
                    //Caso não haja um usuário com o mesmo ID
                    if(usuario == null) 
                        //Retorna NotFound
                        return NotFound(new
                        {
                            Mensagem = "O ID não corresponde a nenhum funcionário"
                        });
                    //Caso haja, retorna o usuário
                    return Ok(usuario);
                }
                return BadRequest(new
                {
                    Mensagem = "Id informado é inválido"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
            
        }

        /// <summary>
        /// Endpoint para buscar o usuário logado
        /// </summary>
        /// <returns>O usuário que está logado</returns>
        //[Authorize]
        [HttpGet("BuscarUsuario")]
        public IActionResult BuscarUsuarioLogado()
        {
            try
            {
                //Recebe o ID do usuário logado
                int id = Convert.ToInt32(HttpContext.User.Claims.FirstOrDefault(u => u.Type == JwtRegisteredClaimNames.Jti).Value);
                //Caso o ID seja maior que 0
                if (id > 0)
                {
                    //Busca o usuário pelo ID
                    Usuario usuario = _usuarioRepository.BuscarUsuario(id);
                    //Caso não haja um usuário com o mesmo ID
                    if (usuario == null)
                        //Retorna NotFound
                        return NotFound(new
                        {
                            Mensagem = "O ID não corresponde a nenhum funcionário"
                        });
                    //Caso haja, retorna o usuário
                    return Ok(usuario);
                }
                return BadRequest(new
                {
                    Mensagem = "Id informado é inválido"
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }

        }

        /// <summary>
        /// Endpoint que lista todos os funcionários 
        /// </summary>
        /// <returns>Lista de Uusários</returns>
        [HttpGet("Funcionarios/{id}")]
        public IActionResult ListarFuncionarios(int id)
        {
            try
            {
                //Instância uma lista de usuários e preenche com funcionarios
                List<FuncionariosViewModel> lista = _usuarioRepository.ListarFuncionarios(id);

                if (lista == null)
                    return NotFound(new
                    {
                        Mensagem = "Não há funcionáros no sistema"
                    });
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
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
            catch (Exception ex)
            {
                return BadRequest(ex);
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
            catch (Exception ex)
            {
                return BadRequest(ex);
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
        [HttpGet("Ranking/{idGestor}")]
        public IActionResult Ranking(int idGestor)
        {
            try
            {
                return Ok(_usuarioRepository.Ranking(idGestor));

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
                return Ok(_usuarioRepository.RankingMobile());

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
                throw;
            }
        }
    }
}
