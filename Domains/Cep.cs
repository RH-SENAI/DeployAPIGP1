using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Cep
    {
        public Cep()
        {
            Localizacaos = new HashSet<Localizacao>();
        }

        public int IdCep { get; set; }
        public string Cep1 { get; set; }

        public virtual ICollection<Localizacao> Localizacaos { get; set; }
    }
}
