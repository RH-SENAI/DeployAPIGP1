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
            AvaliacaousuarioIdUsuarioAvaliadoNavigations = new HashSet<Avaliacaousuario>();
            AvaliacaousuarioIdUsuarioAvaliadorNavigations = new HashSet<Avaliacaousuario>();
            Comentariocursos = new HashSet<Comentariocurso>();
            Comentariodescontos = new HashSet<Comentariodesconto>();
            Cursofavoritos = new HashSet<Cursofavorito>();
            Decisaos = new HashSet<Decisao>();
            Descontofavoritos = new HashSet<Descontofavorito>();
            Feedbacks = new HashSet<Feedback>();
            Grupos = new HashSet<Grupo>();
            Historicos = new HashSet<Historico>();
            Lotacaos = new HashSet<Lotacao>();
            Minhasatividades = new HashSet<Minhasatividade>();
            Registrocursos = new HashSet<Registrocurso>();
            Registrodescontos = new HashSet<Registrodesconto>();
            Registrominhasunidades = new HashSet<Registrominhasunidade>();
        }

        public int IdUsuario { get; set; }
        public byte IdCargo { get; set; }
        public int IdUnidadeSenai { get; set; }
        public byte IdTipoUsuario { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public DateTime DataNascimento { get; set; }
        public int SaldoMoeda { get; set; }
        public int Trofeus { get; set; }
        public string CaminhoFotoPerfil { get; set; }
        public bool UsuarioAtivo { get; set; }
        public decimal? MedFeedbackNeg { get; set; }
        public decimal? MedFeedbackNeu { get; set; }
        public decimal? MedFeedbackPos { get; set; }
        public decimal? MedCursosNeg { get; set; }
        public decimal? MedCursosNeu { get; set; }
        public decimal? MedCursosPos { get; set; }
        public decimal? MedDescontosNeg { get; set; }
        public decimal? MedDescontosNeu { get; set; }
        public decimal? MedDescontosPos { get; set; }
        public decimal? MedSatisfacaoGeral { get; set; }
        public decimal? NotaProdutividade { get; set; }
        public decimal? MediaAvaliacao { get; set; }

        public virtual Cargo IdCargoNavigation { get; set; }
        public virtual Tipousuario IdTipoUsuarioNavigation { get; set; }
        public virtual Unidadesenai IdUnidadeSenaiNavigation { get; set; }
        public virtual ICollection<Atividade> Atividades { get; set; }
        public virtual ICollection<Avaliacaousuario> AvaliacaousuarioIdUsuarioAvaliadoNavigations { get; set; }
        public virtual ICollection<Avaliacaousuario> AvaliacaousuarioIdUsuarioAvaliadorNavigations { get; set; }
        public virtual ICollection<Comentariocurso> Comentariocursos { get; set; }
        public virtual ICollection<Comentariodesconto> Comentariodescontos { get; set; }
        public virtual ICollection<Cursofavorito> Cursofavoritos { get; set; }
        public virtual ICollection<Decisao> Decisaos { get; set; }
        public virtual ICollection<Descontofavorito> Descontofavoritos { get; set; }
        public virtual ICollection<Feedback> Feedbacks { get; set; }
        public virtual ICollection<Grupo> Grupos { get; set; }
        public virtual ICollection<Historico> Historicos { get; set; }
        public virtual ICollection<Lotacao> Lotacaos { get; set; }
        public virtual ICollection<Minhasatividade> Minhasatividades { get; set; }
        public virtual ICollection<Registrocurso> Registrocursos { get; set; }
        public virtual ICollection<Registrodesconto> Registrodescontos { get; set; }
        public virtual ICollection<Registrominhasunidade> Registrominhasunidades { get; set; }
    }
}
