using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Minhasatividade
    {
        public int IdMinhasAtividades { get; set; }
        public int IdAtividade { get; set; }
        public int IdUsuario { get; set; }
        public byte IdSituacaoAtividade { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }
        public string Anotacoes { get; set; }

        public virtual Atividade IdAtividadeNavigation { get; set; }
        public virtual Situacaoatividade IdSituacaoAtividadeNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
    }
}
