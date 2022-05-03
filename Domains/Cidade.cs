using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Cidade
    {
        public Cidade()
        {
            Localizacaos = new HashSet<Localizacao>();
        }

        public byte IdCidade { get; set; }
        public string NomeCidade { get; set; }

        public virtual ICollection<Localizacao> Localizacaos { get; set; }
    }
}
