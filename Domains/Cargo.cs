using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Cargo
    {
        public Cargo()
        {
            Usuarios = new HashSet<Usuario>();
        }

        public byte IdCargo { get; set; }
        public string NomeCargo { get; set; }

        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
