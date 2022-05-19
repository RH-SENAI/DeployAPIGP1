using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Comentariodesconto
    {
        public int IdComentarioDesconto { get; set; }
        public int IdDesconto { get; set; }
        public int IdUsuario { get; set; }
        public decimal AvaliacaoDesconto { get; set; }
        public string ComentarioDesconto1 { get; set; }
        public decimal? Positivo { get; set; }
        public decimal? Neutro { get; set; }
        public decimal? Negativo { get; set; }

        public virtual Desconto IdDescontoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
