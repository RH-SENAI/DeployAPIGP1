using SenaiRH_G1.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SenaiRH_G1.Interfaces
{
    public interface ISetorRepository
    {
        List<Setor> ListarSetores();
    }
}
