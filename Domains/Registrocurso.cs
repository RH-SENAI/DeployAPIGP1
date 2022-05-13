using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Registrocurso
    {
        public int IdRegistroCurso { get; set; }
        public int IdCurso { get; set; }
        public int IdUsuario { get; set; }
        public byte IdSituacaoAtividade { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Situacaoatividade IdSituacaoAtividadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
