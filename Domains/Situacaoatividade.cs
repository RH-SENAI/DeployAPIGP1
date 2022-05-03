using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Situacaoatividade
    {
        public Situacaoatividade()
        {
            Cursos = new HashSet<Curso>();
            Minhasatividades = new HashSet<Minhasatividade>();
        }

        public byte IdSituacaoAtividade { get; set; }
        public string NomeSituacaoAtividade { get; set; }

        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Minhasatividade> Minhasatividades { get; set; }
    }
}
