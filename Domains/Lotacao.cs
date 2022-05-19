using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Lotacao
    {
        public int IdLotacao { get; set; }
        public int? IdGestor { get; set; }
        public int? IdFuncionario { get; set; }
        public string TituloLotacao { get; set; }

        public virtual Usuario IdFuncionarioNavigation { get; set; }
        public virtual Usuario IdGestorNavigation { get; set; }
    }
}
