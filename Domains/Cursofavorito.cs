using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Cursofavorito
    {
        public int IdCursoFavorito { get; set; }
        public int IdCurso { get; set; }
        public int IdUsuario { get; set; }

        public virtual Curso IdCursoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
