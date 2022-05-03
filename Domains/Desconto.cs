using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Desconto
    {
        public Desconto()
        {
            Comentariodescontos = new HashSet<Comentariodesconto>();
            Descontofavoritos = new HashSet<Descontofavorito>();
            Registrodescontos = new HashSet<Registrodesconto>();
        }

        public int IdDesconto { get; set; }
        public int IdEmpresa { get; set; }
        public string NomeDesconto { get; set; }
        public string DescricaoDesconto { get; set; }
        public string CaminhoImagemDesconto { get; set; }
        public DateTime ValidadeDesconto { get; set; }
        public int ValorDesconto { get; set; }
        public string NumeroCupom { get; set; }
        public decimal MediaAvaliacaoDesconto { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual ICollection<Comentariodesconto> Comentariodescontos { get; set; }
        public virtual ICollection<Descontofavorito> Descontofavoritos { get; set; }
        public virtual ICollection<Registrodesconto> Registrodescontos { get; set; }
    }
}
