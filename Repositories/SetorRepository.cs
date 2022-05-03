using SenaiRH_G1.Contexts;
using SenaiRH_G1.Domains;
using SenaiRH_G1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G1.Repositories
{
    public class SetorRepository : ISetorRepository
    {
        private readonly senaiRhContext ctx;
        public SetorRepository(senaiRhContext appContext)
        {
            ctx = appContext;
        }
        public List<Setor> ListarSetores()
        {
            return ctx.Setors.ToList();
        }
    }
}
