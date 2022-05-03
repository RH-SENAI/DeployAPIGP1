using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SenaiRH_G1.Contexts;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G1.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class SetoresController : ControllerBase
    {
        private readonly senaiRhContext _context;
        public SetoresController(senaiRhContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Endpoint que lista os setores
        /// </summary>
        /// <returns>Lista de setores</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Setor>>> GetSetors()
        {
            return await _context.Setors.ToListAsync();
        }
    }
}
