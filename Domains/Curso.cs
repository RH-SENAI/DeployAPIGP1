using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Curso
    {
        public Curso()
        {
            Comentariocursos = new HashSet<Comentariocurso>();
            Cursofavoritos = new HashSet<Cursofavorito>();
            Registrocursos = new HashSet<Registrocurso>();
        }

        public int IdCurso { get; set; }
        public int IdEmpresa { get; set; }
        public byte IdSituacaoInscricao { get; set; }
        public string NomeCurso { get; set; }
        public string DescricaoCurso { get; set; }
        public string SiteCurso { get; set; }
        public bool ModalidadeCurso { get; set; }
        public string CaminhoImagemCurso { get; set; }
        public int ValorCurso { get; set; }
        public int CargaHoraria { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public decimal MediaAvaliacaoCurso { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Situacaoatividade IdSituacaoInscricaoNavigation { get; set; }
        public virtual ICollection<Comentariocurso> Comentariocursos { get; set; }
        public virtual ICollection<Cursofavorito> Cursofavoritos { get; set; }
        public virtual ICollection<Registrocurso> Registrocursos { get; set; }
    }
}
