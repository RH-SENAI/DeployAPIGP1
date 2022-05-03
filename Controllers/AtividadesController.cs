using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenaiRH_G1.Contexts;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using SenaiRH_G1.Repositories;
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
    public class AtividadesController : ControllerBase
    {
        private readonly senaiRhContext _context;
        private readonly IAtividadeRepository _atividadeRepository;
        public AtividadesController(senaiRhContext context, IAtividadeRepository repo)
        {
            _context = context;
            _atividadeRepository = repo;
        }


        //[Authorize(Roles = "2")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Atividade>>> GetAtividades()
        {
            return await _context.Atividades.ToListAsync();
        }

        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult PostAtividade(Atividade atividade)
        {
            try
            {

                if (atividade.NomeAtividade == null)
                {
                    return BadRequest(new
                    {
                        Mensagem = "Os dados estão incorretos"
                    });
                }
                atividade.DataCriacao = DateTime.Now;
                _context.Atividades.Add(atividade);
                _context.SaveChanges();

                return StatusCode(201, new
                {
                    Mensagem = "Atividade cadastrada",
                    atividade
                });
            }
            catch (Exception error)
            {

                return BadRequest(error.Message);
            }

        }

        [Authorize(Roles = "2")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEquipamento(int id)
        {
            var atividade = await _context.Atividades.FindAsync(id);
            if (atividade == null)
            {
                return NotFound();
            }

            _context.Atividades.Remove(atividade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        /// <summary>
        /// Endpoint de listar atividades do usuario
        /// </summary>
        /// <param name="id">ID do usuário que tera suas atividades listadas</param>
        /// <returns>Lista de atividades</returns>
        [Authorize]
        [HttpGet("MinhasAtividade/{id}")]
        public IActionResult ListarMinhasAtividades(int id)
        {
            try
            {
                //Busca usuario pelo ID fornecido
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

                //Verifica se o usuario e valido
                if (usuario != null)
                {
                    //Caso seja, retorna status code 200 com a lista de atividade.
                    return Ok(_atividadeRepository.ListarMinhas(id));
                }
                //Caso nao seja
                else
                {
                    //Retorna status code 400 com mensagem de erro
                    return BadRequest(new
                    {
                        Mensagem = "O ID inserido é inválido!"
                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Endpoint de associar um usuario a uma atividade
        /// </summary>
        /// <param name="idUsuario">ID do usuario que sera associado</param>
        /// <param name="idAtividade">ID da atividade que sera associada</param>
        /// <returns>Mensagem de confirmacao</returns>
        [Authorize]
        [HttpPost("Associar/{idUsuario}")]
        public IActionResult AssociarAtividade(int idUsuario, int idAtividade)
        {
            try
            {
                //Busca atividade pelo ID fornecido.
                Atividade atividade = _context.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);

                //Busca usuario fornecido
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

                //Verifica se atividade e usuario fornecidos sao validos
                if (usuario != null && atividade != null)
                {
                    //Caso valido, chama metodo de AssociarAtividade
                    _atividadeRepository.AssociarAtividade(idUsuario, idAtividade);

                    //Ao finalizar, retorna status code 200 com mensagem de sucesso.
                    return Ok(new
                    {   
                        Mensagem = "O usuário foi associado a atividade!"
                    });
                }
                //Caso nao seja valido
                else
                {
                    //Retorna status code 400 com mensagem de erro
                    return BadRequest(new
                    {
                        Mensagem = "O ID usuário ou o ID Atividade são inválidos;"
                    });
                };
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Endpoint de finalizar uma atividade que esta em producao
        /// </summary>
        /// <param name="idAtividade">ID da atividade que sera finalizada</param>
        /// <returns>Mensagem de confirmacao</returns>
        [Authorize]
        [HttpPatch("FinalizarAtividade/{idAtividade}")]
        public IActionResult FinalizarAtividade(int idAtividade)
        {
            try
            {
                //Busca o ID do usuario logado
                int idUsuario = Convert.ToInt32(HttpContext.User.Claims.First(c => c.Type == JwtRegisteredClaimNames.Jti).Value);

                //Busca atividade pelo ID fornecido
                Atividade atividade = _context.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);

                //Busca usuario pelo ID do usuário logado
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

                //Busca associaçao entre o usuario e a atividade
                Minhasatividade minhaAtividade = _context.Minhasatividades.FirstOrDefault(a => a.IdAtividade == idAtividade && a.IdUsuario == idUsuario);

                //Verifica se atividade e usuario fornecidos sao validos
                if (atividade != null && usuario != null)
                {
                    //Caso sejam validos, verifica se associacao entre funcionario e atividade e existente
                    if (minhaAtividade != null)
                    {
                        //Caso seja existente, chama o metoodo de Finalizar a atividade
                        _atividadeRepository.FinalizarAtividade(idUsuario, idAtividade);

                        //Verifica se a atividade tem necessidade de validacao
                        if (atividade.NecessarioValidar)
                        {
                            //Caso a atividade tenha necessidade de validar, a atividade tera seu status alterado e retornara status code 200 com mensagem com essa informação.
                            return Ok(new
                            {
                                Mensagem = "Sua atividade está aguardando confirmação do administrador!"
                            });
                        }
                        //Caso nao tenha necessidade de validação
                        else
                        {
                            //Retornara status code 200 com uma mensagem com a confirmacao da conclusao da atividade
                            return Ok(new
                            {
                                Mensagem = "Sua atividade foi finalizada com sucesso!"
                            });
                        }
                    }
                    //Caso nao seja existente
                    else
                    {
                        //Retorn status code 400 com mensagem de erro
                        return BadRequest(new
                        {
                            Mensagem = "O usuário não está associado a atividade"
                        });
                    }

                }
                //Caso nao sejam válidos
                else
                {
                    //Retorna status code 400 com mensagem de erro.
                    return BadRequest(new
                    {
                        Mensagem = "Os ID's informados são inválidos!"
                    });

                }

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Endpoint de validar uma atividade que foi finalizada pelo usuário, poram, precisa de validacao.
        /// </summary>
        /// <param name="idAtividade">ID da atividae que sera validada.</param>
        /// <param name="idUsuario">ID do usuario que tera sua atividade validada.</param>
        /// <returns>Mensagem de confirmacao</returns>
        //[Authorize(Roles = "2")]
        [HttpPatch("ValidarAtividade/{idAtividade}/{idUsuario}")]
        public IActionResult ValidarAtividade(int idAtividade, int idUsuario)
        {
            try
            {
                //Busca associação entre a atividade e o usuario
                Minhasatividade minhaAtividade = _context.Minhasatividades.FirstOrDefault(a => a.IdAtividade == idAtividade && a.IdUsuario == idUsuario);

                // Busca atividade pelo ID fornecido
                Atividade atividade = _context.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);

                //Busca usuario pelo ID fornecido
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

                //Verifica se atividade e usuario fornecidos sao validos
                if (atividade != null && usuario != null)
                {
                    //Caso sejam, verifica se associacao entre funcionário e atividade e existente
                    if (minhaAtividade != null)
                    {
                        //Caso seja, chamara o método que valida atividade
                        _atividadeRepository.ValidarAtividade(idAtividade, idUsuario);

                        //Ao finalizar, retornara status code 200 com mensagem de sucesso.
                        return Ok(new
                        {
                            Mensagem = "A atividade foi validada!"
                        });
                    }
                    //Caso nao seja
                    else
                    {
                        //Retorna status code 400 com mensagem de erro.
                        return BadRequest(new
                        {
                            Mensagem = "O usuário não está associado a essa atividade!"
                        });
                    }
                }
                //Caso nao sejam
                else
                {
                    //Retornam status code 400 com mensagem de erro.
                    return BadRequest(new
                    {
                        Mensagem = "Os ID's inseridos são inválidos!"
                    });
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }

        }
        [HttpGet("ListaValidar")]
        public IActionResult ListaValidar()
        {
            try
            {
                return Ok(_atividadeRepository.ListaValidar());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}