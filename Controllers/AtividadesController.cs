using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenaiRH_G1.Contexts;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using SenaiRH_G1.Repositories;
using SenaiRH_G1.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
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
        public IActionResult GetAtividades()
        {
            
            try
            {
                List<Atividade> listaAtividade = _atividadeRepository.ListarTodas();

                return Ok(listaAtividade);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("ListarUltima/")]
        public IActionResult GetUltimaAtividade()
        {
            try
            {
                Atividade listaAtividade = _atividadeRepository.BuscarUltima();

                return Ok(listaAtividade);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet("ListarObrigatorias/")]
        public IActionResult GetAtividadesObrigatorias()
        {
            try
            {
                List<Atividade> listaAtividade = _atividadeRepository.ListarObrigatorias();

                return Ok(listaAtividade);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        [HttpGet("ListarExtras/")]
        public IActionResult GetAtividadesExtras()
        {
            try
            {
                List<Atividade> listaAtividade = _atividadeRepository.ListarExtras();

                return Ok(listaAtividade);

            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            MinhasAtividadesViewModel atividade = _atividadeRepository.BuscarPorId(id);
            
            return StatusCode(200, new
            {
                atividade
            });

        }

        //[Authorize(Roles = "2")]
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
                atividade.DataCadastro = DateTime.Now;
                atividade.IdSituacaoAtividade = 4;
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

                return BadRequest(error);
            }

        }

        //[Authorize(Roles = "2")]
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
        /// Endpoint de listar atividades do usuário
        /// </summary>
        /// <param name="id">ID do usuário que terá suas atividades listadas</param>
        /// <returns>Lista de atividades</returns>
        //[Authorize]
        [HttpGet("MinhasAtividade/{id}")]
        public IActionResult ListarMinhasAtividades(int id)
        {
            try
            {
                //Busca usuário pelo ID fornecido
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

                //Verifica se o usuário é válido
                if (usuario != null)
                {
                    //Caso seja, retorna status code 200 com a lista de atividade.
                    return Ok(_atividadeRepository.ListarMinhas(id));
                }
                //Caso não seja
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

        [HttpGet("MinhasAtividadeFinalizadas/{id}")]
        public IActionResult ListarMinhasAtividadesFinalizadas(int id)
        {
            try
            {
                //Busca usuário pelo ID fornecido
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

                //Verifica se o usuário é válido
                if (usuario != null)
                {
                    //Caso seja, retorna status code 200 com a lista de atividade.
                    return Ok(_atividadeRepository.ListarMinhasFinalizadas(id));
                }
                //Caso não seja
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

        //[Authorize]
        [HttpGet("MinhasAtividadeExtra/{id}")]
        public IActionResult ListarMinhasAtividadesExtras(int id)
        {
            try
            {
                //Busca usuário pelo ID fornecido
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == id);

                //Verifica se o usuário é válido
                if (usuario != null)
                {
                    //Caso seja, retorna status code 200 com a lista de atividade.
                    return Ok(_atividadeRepository.ListarMinhasExtras(id));
                }
                //Caso não seja
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
        /// Endpoint de associar um usuário à uma atividade
        /// </summary>
        /// <param name="idUsuario">ID do usuário que será associado</param>
        /// <param name="idAtividade">ID da atividade que será associada</param>
        /// <returns>Mensagem de confirmação</returns>
        /// [Authorize]
        [HttpPost("Associar/{idUsuario}/{idAtividade}")]
        public IActionResult AssociarAtividade(int idUsuario, int idAtividade)
        {
            try
            {
                //Busca atividade pelo ID fornecido.
                Atividade atividade = _context.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);

                //Busca usuário fornecido
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

                //Verifica se atividade e usuário fornecidos são válidos
                if (usuario != null && atividade != null)
                {
                    //Caso válido, chama método de AssociarAtividade
                    _atividadeRepository.AssociarAtividade(idUsuario, idAtividade);

                    //Ao finalizar, retorna status code 200 com mensagem de sucesso.
                    return Ok(new
                    {
                        Mensagem = "O usuário foi associado a atividade!"
                    });
                }
                //Caso não seja válido
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
        /// Endpoint de finalizar uma atividade que está em produção
        /// </summary>
        /// <param name="idAtividade">ID da atividade que será finalizada</param>
        /// /// <param name="idUsuario">ID do usuário que terá sua atividade finalizada</param>
        /// <param name="file">Arquivo de comprovação de finalização da atividade</param>
        /// <returns>Mensagem de confirmação</returns>
        //[Authorize]

        [HttpPost("FinalizarAtividade/{idAtividade}/{idUsuario}")]
        public IActionResult FinalizarAtividade(int idAtividade, IFormFile file, int idUsuario)
        {
            try
            {

                //Busca atividade pelo ID fornecido
                Atividade atividade = _context.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);

                //Busca usuário pelo ID do usuário logado
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

                //Busca associação entre o usuário e a atividade
                Minhasatividade minhaAtividade = _context.Minhasatividades.FirstOrDefault(a => a.IdAtividade == idAtividade && a.IdUsuario == idUsuario);

                //Verifica se atividade e usuário fornecidos são válidos
                if (atividade != null && usuario != null)
                {
                    //Caso sejam válidos, verifica se associação entre funcionário e atividade é existente
                    if (minhaAtividade != null)
                    {
                        //Caso seja existente, chama o método de Finalizar a atividade
                         _atividadeRepository.FinalizarAtividade(idUsuario, idAtividade, file);

                        //Verifica se a atividade tem necessidade de validação
                        if (atividade.NecessarioValidar)
                        {
                            //Caso a atividade tenha necessidade de validar, a atividade terá seu status alterado e retornará status code 200 com mensagem com essa informação.
                            return Ok(new
                            {
                                Mensagem = "Sua atividade está aguardando confirmação do administrador!"
                            });
                        }
                        //Caso não tenha necessidade de validação
                        else
                        {
                            //Retornará status code 200 com uma mensagem com a confirmação da conclusão da atividade
                            return Ok(new
                            {
                                Mensagem = "Sua atividade foi finalizada com sucesso!"
                            });
                        }
                    }
                    //Caso não seja existente
                    else
                    {
                        //Retorn status code 400 com mensagem de erro
                        return BadRequest(new
                        {
                            Mensagem = "O usuário não está associado a atividade"
                        });
                    }

                }
                //Caso não sejam válidos
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
        /// Endpoint de validar uma atividade que foi finalizada pelo usuário, porém, precisa de validação.
        /// </summary>
        /// <param name="idAtividade">ID da atividae que será validada.</param>
        /// <param name="idUsuario">ID do usuario que terá sua atividade validada.</param>
        /// <returns>Mensagem de confirmação</returns>
        //[Authorize(Roles = "2")]
        [HttpPatch("ValidarAtividade/{idAtividade}/{idUsuario}")]
        public IActionResult ValidarAtividade(int idAtividade, int idUsuario)
        {
            try
            {
                //Busca associação entre a atividade e o usuário
                Minhasatividade minhaAtividade = _context.Minhasatividades.FirstOrDefault(a => a.IdAtividade == idAtividade && a.IdUsuario == idUsuario);

                // Busca atividade pelo ID fornecido
                Atividade atividade = _context.Atividades.FirstOrDefault(a => a.IdAtividade == idAtividade);

                //Busca usuário pelo ID fornecido
                Usuario usuario = _context.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);

                //Verifica se atividade e usuário fornecidos são válidos
                if (atividade != null && usuario != null)
                {
                    //Caso sejam, verifica se associação entre funcionário e atividade é existente
                    if (minhaAtividade != null)
                    {
                        //Caso seja, chamará o método que valida atividade
                        _atividadeRepository.ValidarAtividade(idAtividade, idUsuario);

                        //Ao finalizar, retornará status code 200 com mensagem de sucesso.
                        return Ok(new
                        {
                            Mensagem = "A atividade foi validada!"
                        });
                    }
                    //Caso não seja
                    else
                    {
                        //Retorna status code 400 com mensagem de erro.
                        return BadRequest(new
                        {
                            Mensagem = "O usuário não está associado a essa atividade!"
                        });
                    }
                }
                //Caso não sejam
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
        [HttpPatch("RecusarAtividade/{idMinhasAtividades}")]
        public IActionResult RecusarAtividade(int idMinhasAtividades)
        {
            try
            {
                if (idMinhasAtividades > 0)
                {
                    _atividadeRepository.RecusarAtividade(idMinhasAtividades);
                    return Ok();
                };
                return BadRequest(new
                {
                    Mensagem = "O id inserido é inválido"
                });
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}