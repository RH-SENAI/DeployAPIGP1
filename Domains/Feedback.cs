using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Feedback
    {
        public int IdFeedBack { get; set; }
        public int IdDecisao { get; set; }
        public int IdUsuario { get; set; }
        public decimal? Positivo { get; set; }
        public decimal? Neutro { get; set; }
        public decimal? Negativo { get; set; }
        public string ComentarioFeedBack { get; set; }
        public DateTime DataPublicacao { get; set; }
        public int ValorMoedas { get; set; }

        public virtual Decisao IdDecisaoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
