using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Comentariocurso
    {
        public int IdComentarioCurso { get; set; }
        public int IdCurso { get; set; }
        public int IdUsuario { get; set; }
        public decimal AvaliacaoComentario { get; set; }
        public string ComentarioCurso1 { get; set; }
        public decimal? Positivo { get; set; }
        public decimal? Neutro { get; set; }
        public decimal? Negativo { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
