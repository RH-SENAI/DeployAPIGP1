using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Situacaoatividade
    {
        public Situacaoatividade()
        {
            Atividades = new HashSet<Atividade>();
            Cursos = new HashSet<Curso>();
            Minhasatividades = new HashSet<Minhasatividade>();
            Registrocursos = new HashSet<Registrocurso>();
        }

        public byte IdSituacaoAtividade { get; set; }
        public string NomeSituacaoAtividade { get; set; }

        public virtual ICollection<Atividade> Atividades { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Minhasatividade> Minhasatividades { get; set; }
        public virtual ICollection<Registrocurso> Registrocursos { get; set; }
    }
}
