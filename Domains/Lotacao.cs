using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Lotacao
    {
        public int IdLotacçao { get; set; }
        public int IdFuncionario { get; set; }
        public byte IdGrupo { get; set; }

        public virtual Usuario IdFuncionarioNavigation { get; set; }
        public virtual Grupo IdGrupoNavigation { get; set; }
    }
}
