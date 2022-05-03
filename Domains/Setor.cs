using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Setor
    {
        public Setor()
        {
            Cargos = new HashSet<Cargo>();
            Minhasatividades = new HashSet<Minhasatividade>();
        }

        public byte IdSetor { get; set; }
        public string NomeSetor { get; set; }

        public virtual ICollection<Cargo> Cargos { get; set; }
        public virtual ICollection<Minhasatividade> Minhasatividades { get; set; }
    }
}
