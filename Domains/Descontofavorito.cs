using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Descontofavorito
    {
        public int IdDescontoFavorito { get; set; }
        public int IdDesconto { get; set; }
        public int IdUsuario { get; set; }

        public virtual Desconto IdDescontoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
