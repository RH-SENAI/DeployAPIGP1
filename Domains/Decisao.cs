using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Decisao
    {
        public Decisao()
        {
            Feedbacks = new HashSet<Feedback>();
        }

        public int IdDecisao { get; set; }
        public int IdUsuario { get; set; }
        public string DescricaoDecisao { get; set; }
        public DateTime DataDecisao { get; set; }
        public DateTime PrazoDeAvaliacao { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
    }
}
