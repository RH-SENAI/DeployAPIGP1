using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Historico
    {
        public int IdHistorico { get; set; }
        public int IdUsuario { get; set; }
        public DateTime AtualizadoEm { get; set; }
        public decimal? NivelSatisfacao { get; set; }
        public decimal? NotaProdutividade { get; set; }
        public decimal? MediaAvaliacao { get; set; }
        public int? SaldoMoeda { get; set; }
        public int? Trofeus { get; set; }
        public int? QtdDeTotalAtividade { get; set; }
        public int? QtdDeTotalDescontos { get; set; }
        public int? QtdDeTotalCursos { get; set; }

        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
