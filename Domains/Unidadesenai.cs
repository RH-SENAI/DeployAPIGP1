using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Unidadesenai
    {
        public Unidadesenai()
        {
            Avaliacaounidadesenais = new HashSet<Avaliacaounidadesenai>();
            Usuarios = new HashSet<Usuario>();
        }

        public int IdUnidadeSenai { get; set; }
        public int? IdLocalizacao { get; set; }
        public string NomeUnidadeSenai { get; set; }
        public decimal MediaAvaliacaoUnidadeSenai { get; set; }
        public decimal MediaSatisfacaoUnidadeSenai { get; set; }
        public string TelefoneUnidadeSenai { get; set; }
        public string EmailUnidadeSenai { get; set; }

        public virtual Localizacao IdLocalizacaoNavigation { get; set; }
        public virtual ICollection<Avaliacaounidadesenai> Avaliacaounidadesenais { get; set; }
        public virtual ICollection<Usuario> Usuarios { get; set; }
    }
}
