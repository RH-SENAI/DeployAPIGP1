using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Atividade
    {
        public Atividade()
        {
            Minhasatividades = new HashSet<Minhasatividade>();
        }

        public int IdAtividade { get; set; }
        public byte IdSituacaoAtividade { get; set; }
        public int IdGestorCadastro { get; set; }
        public string NomeAtividade { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }
        public int RecompensaMoeda { get; set; }
        public int RecompensaTrofeu { get; set; }
        public string DescricaoAtividade { get; set; }
        public bool NecessarioValidar { get; set; }
        public bool Equipe { get; set; }
        public bool Obrigatorio { get; set; }

        public virtual Usuario IdGestorCadastroNavigation { get; set; }
        public virtual Situacaoatividade IdSituacaoAtividadeNavigation { get; set; }
        public virtual ICollection<Minhasatividade> Minhasatividades { get; set; }
    }
}
