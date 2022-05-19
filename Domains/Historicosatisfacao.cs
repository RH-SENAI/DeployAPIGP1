using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Historicosatisfacao
    {
        public int IdHistoricoSatisfacao { get; set; }
        public int IdUsuario { get; set; }
        public DateTime AtualizadoEm { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
