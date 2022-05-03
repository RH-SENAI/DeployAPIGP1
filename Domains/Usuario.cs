using System;
using System.Collections.Generic;

#nullable disable

namespace SenaiRH_G1.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Atividades = new HashSet<Atividade>();
            Avaliacaounidadesenais = new HashSet<Avaliacaounidadesenai>();
            AvaliacaousuarioIdUsuarioAvaliadoNavigations = new HashSet<Avaliacaousuario>();
            AvaliacaousuarioIdUsuarioAvaliadorNavigations = new HashSet<Avaliacaousuario>();
            Comentariocursos = new HashSet<Comentariocurso>();
            Comentariodescontos = new HashSet<Comentariodesconto>();
            Cursofavoritos = new HashSet<Cursofavorito>();
            Decisaos = new HashSet<Decisao>();
            Descontofavoritos = new HashSet<Descontofavorito>();
            Feedbacks = new HashSet<Feedback>();
            Minhasatividades = new HashSet<Minhasatividade>();
            Registrocursos = new HashSet<Registrocurso>();
            Registrodescontos = new HashSet<Registrodesconto>();
        }

        public int IdUsuario { get; set; }
        public byte IdCargo { get; set; }
        public int IdUnidadeSenai { get; set; }
        public byte IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public short Vantagens { get; set; }
        public decimal NivelSatisfacao { get; set; }
        public string Cpf { get; set; }
        public int SaldoMoeda { get; set; }
        public int Trofeus { get; set; }
        public string LocalizacaoUsuario { get; set; }
        public string CaminhoFotoPerfil { get; set; }
        public bool? UsuarioAtivo { get; set; }

        public virtual Cargo IdCargoNavigation { get; set; }
        public virtual Tipousuario IdTipoUsuarioNavigation { get; set; }
        public virtual Unidadesenai IdUnidadeSenaiNavigation { get; set; }
        public virtual ICollection<Atividade> Atividades { get; set; }
        public virtual ICollection<Avaliacaounidadesenai> Avaliacaounidadesenais { get; set; }
        public virtual ICollection<Avaliacaousuario> AvaliacaousuarioIdUsuarioAvaliadoNavigations { get; set; }
        public virtual ICollection<Avaliacaousuario> AvaliacaousuarioIdUsuarioAvaliadorNavigations { get; set; }
        public virtual ICollection<Comentariocurso> Comentariocursos { get; set; }
        public virtual ICollection<Comentariodesconto> Comentariodescontos { get; set; }
        public virtual ICollection<Cursofavorito> Cursofavoritos { get; set; }
        public virtual ICollection<Decisao> Decisaos { get; set; }
        public virtual ICollection<Descontofavorito> Descontofavoritos { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Minhasatividade> Minhasatividades { get; set; }
        public virtual ICollection<Registrocurso> Registrocursos { get; set; }
        public virtual ICollection<Registrodesconto> Registrodescontos { get; set; }
    }
}
