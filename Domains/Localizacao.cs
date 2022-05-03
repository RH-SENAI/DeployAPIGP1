using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Localizacao
    {
        public Localizacao()
        {
            Empresas = new HashSet<Empresa>();
            Unidadesenais = new HashSet<Unidadesenai>();
        }

        public int IdLocalizacao { get; set; }
        public int IdCep { get; set; }
        public int IdBairro { get; set; }
        public int IdLogradouro { get; set; }
        public byte IdCidade { get; set; }
        public byte IdEstado { get; set; }
        public string Numero { get; set; }

        public virtual Bairro IdBairroNavigation { get; set; }
        public virtual Cep IdCepNavigation { get; set; }
        public virtual Cidade IdCidadeNavigation { get; set; }
        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual Logradouro IdLogradouroNavigation { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
        public virtual ICollection<Unidadesenai> Unidadesenais { get; set; }
    }
}
