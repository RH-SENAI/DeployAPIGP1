using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Cursos = new HashSet<Curso>();
            Descontos = new HashSet<Desconto>();
        }

        public int IdEmpresa { get; set; }
        public int IdLocalizacao { get; set; }
        public string NomeEmpresa { get; set; }
        public string EmailEmpresa { get; set; }
        public string TelefoneEmpresa { get; set; }
        public string CaminhoImagemEmpresa { get; set; }

        public virtual Localizacao IdLocalizacaoNavigation { get; set; }
        public virtual ICollection<Curso> Cursos { get; set; }
        public virtual ICollection<Desconto> Descontos { get; set; }
    }
}
