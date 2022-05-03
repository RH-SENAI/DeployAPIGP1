using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Avaliacaounidadesenai
    {
        public int IdAvalicaoUnidadeSenai { get; set; }
        public int IdUnidadeSenai { get; set; }
        public int IdUsuario { get; set; }
        public decimal MediaAvaliacaoUnidadeSenai { get; set; }
        public string ComentarioUnidadeSenai { get; set; }
        public int ValorMoeda { get; set; }

        public virtual Unidadesenai IdUnidadeSenaiNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
