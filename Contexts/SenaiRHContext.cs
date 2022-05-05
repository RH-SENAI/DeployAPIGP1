using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SenaiRH_G1.Domains;

#nullable disable

namespace SenaiRH_G1.Contexts
{
    public partial class senaiRhContext : DbContext
    {
        public senaiRhContext()
        {
        }

        public senaiRhContext(DbContextOptions<senaiRhContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Atividade> Atividades { get; set; }
        public virtual DbSet<Avaliacaounidadesenai> Avaliacaounidadesenais { get; set; }
        public virtual DbSet<Avaliacaousuario> Avaliacaousuarios { get; set; }
        public virtual DbSet<Bairro> Bairros { get; set; }
        public virtual DbSet<Cargo> Cargos { get; set; }
        public virtual DbSet<Cep> Ceps { get; set; }
        public virtual DbSet<Cidade> Cidades { get; set; }
        public virtual DbSet<Comentariocurso> Comentariocursos { get; set; }
        public virtual DbSet<Comentariodesconto> Comentariodescontos { get; set; }
        public virtual DbSet<Curso> Cursos { get; set; }
        public virtual DbSet<Cursofavorito> Cursofavoritos { get; set; }
        public virtual DbSet<Decisao> Decisaos { get; set; }
        public virtual DbSet<Desconto> Descontos { get; set; }
        public virtual DbSet<Descontofavorito> Descontofavoritos { get; set; }
        public virtual DbSet<Empresa> Empresas { get; set; }
        public virtual DbSet<Estado> Estados { get; set; }
        public virtual DbSet<Feedback> Feedbacks { get; set; }
        public virtual DbSet<Localizacao> Localizacaos { get; set; }
        public virtual DbSet<Logradouro> Logradouros { get; set; }
        public virtual DbSet<Minhasatividade> Minhasatividades { get; set; }
        public virtual DbSet<Registrocurso> Registrocursos { get; set; }
        public virtual DbSet<Registrodesconto> Registrodescontos { get; set; }
        public virtual DbSet<Setor> Setors { get; set; }
        public virtual DbSet<Situacaoatividade> Situacaoatividades { get; set; }
        public virtual DbSet<Tipousuario> Tipousuarios { get; set; }
        public virtual DbSet<Unidadesenai> Unidadesenais { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=senairh.database.windows.net; initial catalog=DBProjetoSenaiRH; user Id=admin_projeto; pwd=SenaiRH123*\n;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Atividade>(entity =>
            {
                entity.HasKey(e => e.IdAtividade)
                    .HasName("PK__ATIVIDAD__E6E8EAE2F3C8506D");

                entity.ToTable("ATIVIDADE");

                entity.Property(e => e.IdAtividade).HasColumnName("idAtividade");

                entity.Property(e => e.DataConclusao)
                    .HasColumnType("date")
                    .HasColumnName("dataConclusao");

                entity.Property(e => e.DataCriacao)
                    .HasColumnType("datetime")
                    .HasColumnName("dataCriacao");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("dataInicio");

                entity.Property(e => e.DescricaoAtividade)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("descricaoAtividade");

                entity.Property(e => e.IdGestorCadastro).HasColumnName("idGestorCadastro");

                entity.Property(e => e.NecessarioValidar).HasColumnName("necessarioValidar");

                entity.Property(e => e.NomeAtividade)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeAtividade");

                entity.Property(e => e.RecompensaMoeda).HasColumnName("recompensaMoeda");

                entity.Property(e => e.RecompensaTrofeu).HasColumnName("recompensaTrofeu");

                entity.HasOne(d => d.IdGestorCadastroNavigation)
                    .WithMany(p => p.Atividades)
                    .HasForeignKey(d => d.IdGestorCadastro)
                    .HasConstraintName("FK__ATIVIDADE__idGes__3F115E1A");
            });

            modelBuilder.Entity<Avaliacaounidadesenai>(entity =>
            {
                entity.HasKey(e => e.IdAvalicaoUnidadeSenai)
                    .HasName("PK__AVALIACA__BA46550F44F06E02");

                entity.ToTable("AVALIACAOUNIDADESENAI");

                entity.Property(e => e.IdAvalicaoUnidadeSenai).HasColumnName("idAvalicaoUnidadeSenai");

                entity.Property(e => e.ComentarioUnidadeSenai)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("comentarioUnidadeSenai");

                entity.Property(e => e.IdUnidadeSenai).HasColumnName("idUnidadeSenai");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.MediaAvaliacaoUnidadeSenai)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("mediaAvaliacaoUnidadeSenai");

                entity.Property(e => e.ValorMoeda).HasColumnName("valorMoeda");

                entity.HasOne(d => d.IdUnidadeSenaiNavigation)
                    .WithMany(p => p.Avaliacaounidadesenais)
                    .HasForeignKey(d => d.IdUnidadeSenai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AVALIACAO__idUni__07C12930");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Avaliacaounidadesenais)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AVALIACAO__idUsu__08B54D69");
            });

            modelBuilder.Entity<Avaliacaousuario>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacaoUsuario)
                    .HasName("PK__AVALIACA__08B8D28568CC1CE5");

                entity.ToTable("AVALIACAOUSUARIO");

                entity.Property(e => e.IdAvaliacaoUsuario).HasColumnName("idAvaliacaoUsuario");

                entity.Property(e => e.AvaliacaoUsuario1)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("avaliacaoUsuario");

                entity.Property(e => e.IdUsuarioAvaliado).HasColumnName("idUsuarioAvaliado");

                entity.Property(e => e.IdUsuarioAvaliador).HasColumnName("idUsuarioAvaliador");

                entity.Property(e => e.ValorMoedas).HasColumnName("valorMoedas");

                entity.HasOne(d => d.IdUsuarioAvaliadoNavigation)
                    .WithMany(p => p.AvaliacaousuarioIdUsuarioAvaliadoNavigations)
                    .HasForeignKey(d => d.IdUsuarioAvaliado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AVALIACAO__idUsu__1BC821DD");

                entity.HasOne(d => d.IdUsuarioAvaliadorNavigation)
                    .WithMany(p => p.AvaliacaousuarioIdUsuarioAvaliadorNavigations)
                    .HasForeignKey(d => d.IdUsuarioAvaliador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AVALIACAO__idUsu__1CBC4616");
            });

            modelBuilder.Entity<Bairro>(entity =>
            {
                entity.HasKey(e => e.IdBairro)
                    .HasName("PK__BAIRRO__86B592A1D1B1853B");

                entity.ToTable("BAIRRO");

                entity.HasIndex(e => e.NomeBairro, "UQ__BAIRRO__72D4FAEC994D6C32")
                    .IsUnique();

                entity.Property(e => e.IdBairro).HasColumnName("idBairro");

                entity.Property(e => e.NomeBairro)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeBairro");
            });

            modelBuilder.Entity<Cargo>(entity =>
            {
                entity.HasKey(e => e.IdCargo)
                    .HasName("PK__CARGO__3D0E29B831C470AB");

                entity.ToTable("CARGO");

                entity.Property(e => e.IdCargo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idCargo");

                entity.Property(e => e.CargaHoraria).HasColumnName("cargaHoraria");

                entity.Property(e => e.IdSetor).HasColumnName("idSetor");

                entity.Property(e => e.NomeCargo)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeCargo");

                entity.HasOne(d => d.IdSetorNavigation)
                    .WithMany(p => p.Cargos)
                    .HasForeignKey(d => d.IdSetor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CARGO__idSetor__7D439ABD");
            });

            modelBuilder.Entity<Cep>(entity =>
            {
                entity.HasKey(e => e.IdCep)
                    .HasName("PK__CEP__398F6FDAF83DDFC6");

                entity.ToTable("CEP");

                entity.HasIndex(e => e.Cep1, "UQ__CEP__D83671A53D5D7173")
                    .IsUnique();

                entity.Property(e => e.IdCep).HasColumnName("idCep");

                entity.Property(e => e.Cep1)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("cep")
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Cidade>(entity =>
            {
                entity.HasKey(e => e.IdCidade)
                    .HasName("PK__CIDADE__559AD0FE884CE1D1");

                entity.ToTable("CIDADE");

                entity.HasIndex(e => e.NomeCidade, "UQ__CIDADE__FF0A5458FCE2009F")
                    .IsUnique();

                entity.Property(e => e.IdCidade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idCidade");

                entity.Property(e => e.NomeCidade)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeCidade");
            });

            modelBuilder.Entity<Comentariocurso>(entity =>
            {
                entity.HasKey(e => e.IdComentarioCurso)
                    .HasName("PK__COMENTAR__71861C419213C811");

                entity.ToTable("COMENTARIOCURSO");

                entity.Property(e => e.IdComentarioCurso).HasColumnName("idComentarioCurso");

                entity.Property(e => e.AvaliacaoComentario)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("avaliacaoComentario");

                entity.Property(e => e.ComentarioCurso1)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("comentarioCurso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Comentariocursos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMENTARI__idCur__2739D489");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentariocursos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMENTARI__idUsu__282DF8C2");
            });

            modelBuilder.Entity<Comentariodesconto>(entity =>
            {
                entity.HasKey(e => e.IdComentarioDesconto)
                    .HasName("PK__COMENTAR__E9D0515770A2B028");

                entity.ToTable("COMENTARIODESCONTO");

                entity.Property(e => e.IdComentarioDesconto).HasColumnName("idComentarioDesconto");

                entity.Property(e => e.AvaliacaoDesconto)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("avaliacaoDesconto");

                entity.Property(e => e.ComentarioDesconto1)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("comentarioDesconto");

                entity.Property(e => e.IdDesconto).HasColumnName("idDesconto");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdDescontoNavigation)
                    .WithMany(p => p.Comentariodescontos)
                    .HasForeignKey(d => d.IdDesconto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMENTARI__idDes__3587F3E0");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentariodescontos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMENTARI__idUsu__367C1819");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__CURSO__8551ED059C8F3729");

                entity.ToTable("CURSO");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.CaminhoImagemCurso)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("caminhoImagemCurso");

                entity.Property(e => e.CargaHoraria).HasColumnName("cargaHoraria");

                entity.Property(e => e.DataFinalizacao)
                    .HasColumnType("date")
                    .HasColumnName("dataFinalizacao");

                entity.Property(e => e.DescricaoCurso)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("descricaoCurso");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.IdSituacaoInscricao).HasColumnName("idSituacaoInscricao");

                entity.Property(e => e.MediaAvaliacaoCurso)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("mediaAvaliacaoCurso");

                entity.Property(e => e.ModalidadeCurso).HasColumnName("modalidadeCurso");

                entity.Property(e => e.NomeCurso)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeCurso");

                entity.Property(e => e.SiteCurso)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("siteCurso");

                entity.Property(e => e.ValorCurso).HasColumnName("valorCurso");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSO__idEmpresa__245D67DE");

                entity.HasOne(d => d.IdSituacaoInscricaoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdSituacaoInscricao)
                    .HasConstraintName("FK__CURSO__idSituaca__40058253");
            });

            modelBuilder.Entity<Cursofavorito>(entity =>
            {
                entity.HasKey(e => e.IdCursoFavorito)
                    .HasName("PK__CURSOFAV__B7680EB11BA7A6DD");

                entity.ToTable("CURSOFAVORITO");

                entity.Property(e => e.IdCursoFavorito).HasColumnName("idCursoFavorito");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Cursofavoritos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSOFAVO__idCur__2EDAF651");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cursofavoritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSOFAVO__idUsu__2FCF1A8A");
            });

            modelBuilder.Entity<Decisao>(entity =>
            {
                entity.HasKey(e => e.IdDecisao)
                    .HasName("PK__DECISAO__181085E6FC04AB89");

                entity.ToTable("DECISAO");

                entity.Property(e => e.IdDecisao).HasColumnName("idDecisao");

                entity.Property(e => e.DataDecisao)
                    .HasColumnType("date")
                    .HasColumnName("dataDecisao");

                entity.Property(e => e.DescricaoDecisao)
                    .IsRequired()
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("descricaoDecisao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.PrazoDeAvaliacao)
                    .HasColumnType("date")
                    .HasColumnName("prazoDeAvaliacao");

                entity.Property(e => e.ResultadoDecisao)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("resultadoDecisao");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Decisaos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DECISAO__idUsuar__151B244E");
            });

            modelBuilder.Entity<Desconto>(entity =>
            {
                entity.HasKey(e => e.IdDesconto)
                    .HasName("PK__DESCONTO__3D5D117AE553C646");

                entity.ToTable("DESCONTO");

                entity.Property(e => e.IdDesconto).HasColumnName("idDesconto");

                entity.Property(e => e.CaminhoImagemDesconto)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("caminhoImagemDesconto");

                entity.Property(e => e.DescricaoDesconto)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("descricaoDesconto");

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.MediaAvaliacaoDesconto)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("mediaAvaliacaoDesconto");

                entity.Property(e => e.NomeDesconto)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeDesconto");

                entity.Property(e => e.NumeroCupom)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("numeroCupom");

                entity.Property(e => e.ValidadeDesconto)
                    .HasColumnType("date")
                    .HasColumnName("validadeDesconto");

                entity.Property(e => e.ValorDesconto).HasColumnName("valorDesconto");

                entity.HasOne(d => d.IdEmpresaNavigation)
                    .WithMany(p => p.Descontos)
                    .HasForeignKey(d => d.IdEmpresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DESCONTO__idEmpr__32AB8735");
            });

            modelBuilder.Entity<Descontofavorito>(entity =>
            {
                entity.HasKey(e => e.IdDescontoFavorito)
                    .HasName("PK__DESCONTO__AE1CB35A0736A7D0");

                entity.ToTable("DESCONTOFAVORITO");

                entity.Property(e => e.IdDescontoFavorito).HasColumnName("idDescontoFavorito");

                entity.Property(e => e.IdDesconto).HasColumnName("idDesconto");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdDescontoNavigation)
                    .WithMany(p => p.Descontofavoritos)
                    .HasForeignKey(d => d.IdDesconto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DESCONTOF__idDes__3D2915A8");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Descontofavoritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DESCONTOF__idUsu__3E1D39E1");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__EMPRESA__75D2CED48C6E3595");

                entity.ToTable("EMPRESA");

                entity.HasIndex(e => e.EmailEmpresa, "UQ__EMPRESA__440803BD8CF4D861")
                    .IsUnique();

                entity.HasIndex(e => e.TelefoneEmpresa, "UQ__EMPRESA__8FB435A97D604DCE")
                    .IsUnique();

                entity.Property(e => e.IdEmpresa).HasColumnName("idEmpresa");

                entity.Property(e => e.CaminhoImagemEmpresa)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("caminhoImagemEmpresa");

                entity.Property(e => e.EmailEmpresa)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("emailEmpresa");

                entity.Property(e => e.IdLocalizacao).HasColumnName("idLocalizacao");

                entity.Property(e => e.NomeEmpresa)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeEmpresa");

                entity.Property(e => e.TelefoneEmpresa)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefoneEmpresa");

                entity.HasOne(d => d.IdLocalizacaoNavigation)
                    .WithMany(p => p.Empresas)
                    .HasForeignKey(d => d.IdLocalizacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__EMPRESA__idLocal__2180FB33");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__ESTADO__62EA894ABC1D7D1D");

                entity.ToTable("ESTADO");

                entity.HasIndex(e => e.NomeEstado, "UQ__ESTADO__20DB075B1B74AAC4")
                    .IsUnique();

                entity.Property(e => e.IdEstado)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idEstado");

                entity.Property(e => e.NomeEstado)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeEstado");
            });

            modelBuilder.Entity<Feedback>(entity =>
            {
                entity.HasKey(e => e.IdFeedBack)
                    .HasName("PK__FEEDBACK__535470E9CCDCD799");

                entity.ToTable("FEEDBACK");

                entity.Property(e => e.IdFeedBack).HasColumnName("idFeedBack");

                entity.Property(e => e.ComentarioFeedBack)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("comentarioFeedBack");

                entity.Property(e => e.DataPublicacao)
                    .HasColumnType("date")
                    .HasColumnName("dataPublicacao");

                entity.Property(e => e.IdDecisao).HasColumnName("idDecisao");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.NotaDecisao)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("notaDecisao");

                entity.Property(e => e.ValorMoedas).HasColumnName("valorMoedas");

                entity.HasOne(d => d.IdDecisaoNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.IdDecisao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FEEDBACK__idDeci__17F790F9");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FEEDBACK__idUsua__18EBB532");
            });

            modelBuilder.Entity<Localizacao>(entity =>
            {
                entity.HasKey(e => e.IdLocalizacao)
                    .HasName("PK__LOCALIZA__BEC9BF4F45B2E113");

                entity.ToTable("LOCALIZACAO");

                entity.Property(e => e.IdLocalizacao).HasColumnName("idLocalizacao");

                entity.Property(e => e.IdBairro).HasColumnName("idBairro");

                entity.Property(e => e.IdCep).HasColumnName("idCep");

                entity.Property(e => e.IdCidade).HasColumnName("idCidade");

                entity.Property(e => e.IdEstado).HasColumnName("idEstado");

                entity.Property(e => e.IdLogradouro).HasColumnName("idLogradouro");

                entity.Property(e => e.Numero)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("numero");

                entity.HasOne(d => d.IdBairroNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdBairro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idBai__6EF57B66");

                entity.HasOne(d => d.IdCepNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdCep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idCep__6E01572D");

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idCid__70DDC3D8");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idEst__71D1E811");

                entity.HasOne(d => d.IdLogradouroNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdLogradouro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idLog__6FE99F9F");
            });

            modelBuilder.Entity<Logradouro>(entity =>
            {
                entity.HasKey(e => e.IdLogradouro)
                    .HasName("PK__LOGRADOU__C2023C43F3EEFD14");

                entity.ToTable("LOGRADOURO");

                entity.HasIndex(e => e.NomeLogradouro, "UQ__LOGRADOU__9ADBBDF92152CAA6")
                    .IsUnique();

                entity.Property(e => e.IdLogradouro).HasColumnName("idLogradouro");

                entity.Property(e => e.NomeLogradouro)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeLogradouro");
            });

            modelBuilder.Entity<Minhasatividade>(entity =>
            {
                entity.HasKey(e => e.IdMinhasAtividades)
                    .HasName("PK__MINHASAT__4679039D66CEB1B9");

                entity.ToTable("MINHASATIVIDADES");

                entity.Property(e => e.IdMinhasAtividades).HasColumnName("idMinhasAtividades");

                entity.Property(e => e.Anotacoes)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("anotacoes");

                entity.Property(e => e.DataConclusao)
                    .HasColumnType("date")
                    .HasColumnName("dataConclusao");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("dataInicio");

                entity.Property(e => e.IdAtividade).HasColumnName("idAtividade");

                entity.Property(e => e.IdSetor).HasColumnName("idSetor");

                entity.Property(e => e.IdSituacaoAtividade).HasColumnName("idSituacaoAtividade");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdAtividadeNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idAti__10566F31");

                entity.HasOne(d => d.IdSetorNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdSetor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idSet__114A936A");

                entity.HasOne(d => d.IdSituacaoAtividadeNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdSituacaoAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idSit__0F624AF8");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idUsu__123EB7A3");
            });

            modelBuilder.Entity<Registrocurso>(entity =>
            {
                entity.HasKey(e => e.IdRegistroCurso)
                    .HasName("PK__REGISTRO__0FE8B39F1D0C413B");

                entity.ToTable("REGISTROCURSO");

                entity.Property(e => e.IdRegistroCurso).HasColumnName("idRegistroCurso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Registrocursos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROC__idCur__2B0A656D");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Registrocursos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROC__idUsu__2BFE89A6");
            });

            modelBuilder.Entity<Registrodesconto>(entity =>
            {
                entity.HasKey(e => e.IdRegistroDesconto)
                    .HasName("PK__REGISTRO__596321F29610CBFD");

                entity.ToTable("REGISTRODESCONTO");

                entity.Property(e => e.IdRegistroDesconto).HasColumnName("idRegistroDesconto");

                entity.Property(e => e.IdDesconto).HasColumnName("idDesconto");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdDescontoNavigation)
                    .WithMany(p => p.Registrodescontos)
                    .HasForeignKey(d => d.IdDesconto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROD__idDes__395884C4");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Registrodescontos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROD__idUsu__3A4CA8FD");
            });

            modelBuilder.Entity<Setor>(entity =>
            {
                entity.HasKey(e => e.IdSetor)
                    .HasName("PK__SETOR__A37801056298D14F");

                entity.ToTable("SETOR");

                entity.HasIndex(e => e.NomeSetor, "UQ__SETOR__DD7E5C8B054BF1DD")
                    .IsUnique();

                entity.Property(e => e.IdSetor)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSetor");

                entity.Property(e => e.NomeSetor)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeSetor");
            });

            modelBuilder.Entity<Situacaoatividade>(entity =>
            {
                entity.HasKey(e => e.IdSituacaoAtividade)
                    .HasName("PK__SITUACAO__922A8530004D0CE3");

                entity.ToTable("SITUACAOATIVIDADE");

                entity.Property(e => e.IdSituacaoAtividade)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idSituacaoAtividade");

                entity.Property(e => e.NomeSituacaoAtividade)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeSituacaoAtividade");
            });

            modelBuilder.Entity<Tipousuario>(entity =>
            {
                entity.HasKey(e => e.IdTipoUsuario)
                    .HasName("PK__TIPOUSUA__03006BFF5D01DD25");

                entity.ToTable("TIPOUSUARIO");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__TIPOUSUA__A017BD9FBCDFFB02")
                    .IsUnique();

                entity.Property(e => e.IdTipoUsuario)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idTipoUsuario");

                entity.Property(e => e.NomeTipoUsuario)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeTipoUsuario");
            });

            modelBuilder.Entity<Unidadesenai>(entity =>
            {
                entity.HasKey(e => e.IdUnidadeSenai)
                    .HasName("PK__UNIDADES__EDC820B8E3D4C8AF");

                entity.ToTable("UNIDADESENAI");

                entity.HasIndex(e => e.NomeUnidadeSenai, "UQ__UNIDADES__940F41B5AEACEA41")
                    .IsUnique();

                entity.HasIndex(e => e.TelefoneUnidadeSenai, "UQ__UNIDADES__B5490FA41930437D")
                    .IsUnique();

                entity.HasIndex(e => e.EmailUnidadeSenai, "UQ__UNIDADES__C4A0ED97F28F92F7")
                    .IsUnique();

                entity.Property(e => e.IdUnidadeSenai).HasColumnName("idUnidadeSenai");

                entity.Property(e => e.EmailUnidadeSenai)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("emailUnidadeSenai");

                entity.Property(e => e.IdLocalizacao).HasColumnName("idLocalizacao");

                entity.Property(e => e.MediaAvaliacaoUnidadeSenai)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("mediaAvaliacaoUnidadeSenai");

                entity.Property(e => e.MediaSatisfacaoUnidadeSenai)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("mediaSatisfacaoUnidadeSenai");

                entity.Property(e => e.NomeUnidadeSenai)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeUnidadeSenai");

                entity.Property(e => e.TelefoneUnidadeSenai)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefoneUnidadeSenai");

                entity.HasOne(d => d.IdLocalizacaoNavigation)
                    .WithMany(p => p.Unidadesenais)
                    .HasForeignKey(d => d.IdLocalizacao)
                    .HasConstraintName("FK__UNIDADESE__idLoc__778AC167");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A60374FB2A");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.CaminhoFotoPerfil, "UQ__USUARIO__863E7F4296912642")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__USUARIO__AB6E61643F8FC7F3")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__USUARIO__D836E71F2D755829")
                    .IsUnique();

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.CaminhoFotoPerfil)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("caminhoFotoPerfil");

                entity.Property(e => e.Cpf)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("cpf")
                    .IsFixedLength(true);

                entity.Property(e => e.DataNascimento)
                    .HasColumnType("date")
                    .HasColumnName("dataNascimento");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdCargo).HasColumnName("idCargo");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.IdUnidadeSenai).HasColumnName("idUnidadeSenai");

                entity.Property(e => e.LocalizacaoUsuario)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("localizacaoUsuario");

                entity.Property(e => e.NivelSatisfacao)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("nivelSatisfacao");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.SaldoMoeda).HasColumnName("saldoMoeda");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(62)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.Trofeus).HasColumnName("trofeus");

                entity.Property(e => e.UsuarioAtivo).HasColumnName("usuarioAtivo");

                entity.Property(e => e.Vantagens).HasColumnName("vantagens");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__idCargo__02FC7413");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__idTipoU__04E4BC85");

                entity.HasOne(d => d.IdUnidadeSenaiNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdUnidadeSenai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__idUnida__03F0984C");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
