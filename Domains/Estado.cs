using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Estado
    {
        public Estado()
        {
            Localizacaos = new HashSet<Localizacao>();
        }

        public byte IdEstado { get; set; }
        public string NomeEstado { get; set; }

        public virtual ICollection<Localizacao> Localizacaos { get; set; }
    }
}
