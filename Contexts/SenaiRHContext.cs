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
        public virtual DbSet<Grupo> Grupos { get; set; }
        public virtual DbSet<Historico> Historicos { get; set; }
        public virtual DbSet<Localizacao> Localizacaos { get; set; }
        public virtual DbSet<Logradouro> Logradouros { get; set; }
        public virtual DbSet<Lotacao> Lotacaos { get; set; }
        public virtual DbSet<Minhasatividade> Minhasatividades { get; set; }
        public virtual DbSet<Registrocurso> Registrocursos { get; set; }
        public virtual DbSet<Registrodesconto> Registrodescontos { get; set; }
        public virtual DbSet<Registrominhasunidade> Registrominhasunidades { get; set; }
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
                    .HasName("PK__ATIVIDAD__E6E8EAE2C032E150");

                entity.ToTable("ATIVIDADE");

                entity.Property(e => e.IdAtividade).HasColumnName("idAtividade");

                entity.Property(e => e.DataCadastro)
                    .HasColumnType("date")
                    .HasColumnName("dataCadastro");

                entity.Property(e => e.DataConclusao)
                    .HasColumnType("date")
                    .HasColumnName("dataConclusao");

                entity.Property(e => e.DataInicio)
                    .HasColumnType("date")
                    .HasColumnName("dataInicio");

                entity.Property(e => e.DescricaoAtividade)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("descricaoAtividade");

                entity.Property(e => e.Equipe).HasColumnName("equipe");

                entity.Property(e => e.IdGestorCadastro).HasColumnName("idGestorCadastro");

                entity.Property(e => e.IdSituacaoAtividade).HasColumnName("idSituacaoAtividade");

                entity.Property(e => e.NecessarioValidar).HasColumnName("necessarioValidar");

                entity.Property(e => e.NomeAtividade)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeAtividade");

                entity.Property(e => e.Obrigatorio).HasColumnName("obrigatorio");

                entity.Property(e => e.RecompensaMoeda).HasColumnName("recompensaMoeda");

                entity.Property(e => e.RecompensaTrofeu).HasColumnName("recompensaTrofeu");

                entity.HasOne(d => d.IdGestorCadastroNavigation)
                    .WithMany(p => p.Atividades)
                    .HasForeignKey(d => d.IdGestorCadastro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ATIVIDADE__idGes__1446FBA6");

                entity.HasOne(d => d.IdSituacaoAtividadeNavigation)
                    .WithMany(p => p.Atividades)
                    .HasForeignKey(d => d.IdSituacaoAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__ATIVIDADE__idSit__1352D76D");
            });

            modelBuilder.Entity<Avaliacaousuario>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacaoUsuario)
                    .HasName("PK__AVALIACA__08B8D285A28A4178");

                entity.ToTable("AVALIACAOUSUARIO");

                entity.Property(e => e.IdAvaliacaoUsuario).HasColumnName("idAvaliacaoUsuario");

                entity.Property(e => e.AvaliacaoUsuario1)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("avaliacaoUsuario");

                entity.Property(e => e.IdUsuarioAvaliado).HasColumnName("idUsuarioAvaliado");

                entity.Property(e => e.IdUsuarioAvaliador).HasColumnName("idUsuarioAvaliador");

                entity.Property(e => e.ValorMoedas).HasColumnName("valorMoedas");

                entity.HasOne(d => d.IdUsuarioAvaliadoNavigation)
                    .WithMany(p => p.AvaliacaousuarioIdUsuarioAvaliadoNavigations)
                    .HasForeignKey(d => d.IdUsuarioAvaliado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AVALIACAO__idUsu__5614BF03");

                entity.HasOne(d => d.IdUsuarioAvaliadorNavigation)
                    .WithMany(p => p.AvaliacaousuarioIdUsuarioAvaliadorNavigations)
                    .HasForeignKey(d => d.IdUsuarioAvaliador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AVALIACAO__idUsu__5708E33C");
            });

            modelBuilder.Entity<Bairro>(entity =>
            {
                entity.HasKey(e => e.IdBairro)
                    .HasName("PK__BAIRRO__86B592A111B59A9B");

                entity.ToTable("BAIRRO");

                entity.HasIndex(e => e.NomeBairro, "UQ__BAIRRO__72D4FAEC4F5F0872")
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
                    .HasName("PK__CARGO__3D0E29B8EE90F50C");

                entity.ToTable("CARGO");

                entity.Property(e => e.IdCargo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idCargo");

                entity.Property(e => e.NomeCargo)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeCargo");
            });

            modelBuilder.Entity<Cep>(entity =>
            {
                entity.HasKey(e => e.IdCep)
                    .HasName("PK__CEP__398F6FDAD7995037");

                entity.ToTable("CEP");

                entity.HasIndex(e => e.Cep1, "UQ__CEP__D83671A5E715563F")
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
                    .HasName("PK__CIDADE__559AD0FE13F2696E");

                entity.ToTable("CIDADE");

                entity.HasIndex(e => e.NomeCidade, "UQ__CIDADE__FF0A5458DF515C64")
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
                    .HasName("PK__COMENTAR__71861C4184967F3E");

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

                entity.Property(e => e.Negativo)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("negativo");

                entity.Property(e => e.Neutro)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("neutro");

                entity.Property(e => e.Positivo)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("positivo");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Comentariocursos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMENTARI__idCur__2B2A60FE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentariocursos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMENTARI__idUsu__2C1E8537");
            });

            modelBuilder.Entity<Comentariodesconto>(entity =>
            {
                entity.HasKey(e => e.IdComentarioDesconto)
                    .HasName("PK__COMENTAR__E9D05157413EE334");

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

                entity.Property(e => e.Negativo)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("negativo");

                entity.Property(e => e.Neutro)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("neutro");

                entity.Property(e => e.Positivo)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("positivo");

                entity.HasOne(d => d.IdDescontoNavigation)
                    .WithMany(p => p.Comentariodescontos)
                    .HasForeignKey(d => d.IdDesconto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMENTARI__idDes__3A6CA48E");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentariodescontos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMENTARI__idUsu__3B60C8C7");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__CURSO__8551ED055FA6B35F");

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
                    .HasConstraintName("FK__CURSO__idEmpresa__2759D01A");

                entity.HasOne(d => d.IdSituacaoInscricaoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdSituacaoInscricao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSO__idSituaca__284DF453");
            });

            modelBuilder.Entity<Cursofavorito>(entity =>
            {
                entity.HasKey(e => e.IdCursoFavorito)
                    .HasName("PK__CURSOFAV__B7680EB1EA1DAC46");

                entity.ToTable("CURSOFAVORITO");

                entity.Property(e => e.IdCursoFavorito).HasColumnName("idCursoFavorito");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Cursofavoritos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSOFAVO__idCur__33BFA6FF");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cursofavoritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSOFAVO__idUsu__34B3CB38");
            });

            modelBuilder.Entity<Decisao>(entity =>
            {
                entity.HasKey(e => e.IdDecisao)
                    .HasName("PK__DECISAO__181085E6C07ACAB0");

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

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Decisaos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DECISAO__idUsuar__1BE81D6E");
            });

            modelBuilder.Entity<Desconto>(entity =>
            {
                entity.HasKey(e => e.IdDesconto)
                    .HasName("PK__DESCONTO__3D5D117A5758BBBE");

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
                    .HasConstraintName("FK__DESCONTO__idEmpr__379037E3");
            });

            modelBuilder.Entity<Descontofavorito>(entity =>
            {
                entity.HasKey(e => e.IdDescontoFavorito)
                    .HasName("PK__DESCONTO__AE1CB35A4E489DD5");

                entity.ToTable("DESCONTOFAVORITO");

                entity.Property(e => e.IdDescontoFavorito).HasColumnName("idDescontoFavorito");

                entity.Property(e => e.IdDesconto).HasColumnName("idDesconto");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdDescontoNavigation)
                    .WithMany(p => p.Descontofavoritos)
                    .HasForeignKey(d => d.IdDesconto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DESCONTOF__idDes__420DC656");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Descontofavoritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DESCONTOF__idUsu__4301EA8F");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__EMPRESA__75D2CED481AE6BBB");

                entity.ToTable("EMPRESA");

                entity.HasIndex(e => e.EmailEmpresa, "UQ__EMPRESA__440803BD0E7E1D90")
                    .IsUnique();

                entity.HasIndex(e => e.TelefoneEmpresa, "UQ__EMPRESA__8FB435A980A13445")
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
                    .HasConstraintName("FK__EMPRESA__idLocal__247D636F");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__ESTADO__62EA894A1F58890C");

                entity.ToTable("ESTADO");

                entity.HasIndex(e => e.NomeEstado, "UQ__ESTADO__20DB075B32B2A097")
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
                    .HasName("PK__FEEDBACK__535470E982FCA045");

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

                entity.Property(e => e.Negativo)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("negativo");

                entity.Property(e => e.Neutro)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("neutro");

                entity.Property(e => e.Positivo)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("positivo");

                entity.Property(e => e.ValorMoedas).HasColumnName("valorMoedas");

                entity.HasOne(d => d.IdDecisaoNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.IdDecisao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FEEDBACK__idDeci__1EC48A19");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FEEDBACK__idUsua__1FB8AE52");
            });

            modelBuilder.Entity<Grupo>(entity =>
            {
                entity.HasKey(e => e.IdGrupo)
                    .HasName("PK__GRUPO__EC597A871AA53BB6");

                entity.ToTable("GRUPO");

                entity.HasIndex(e => e.NomeGrupo, "UQ__GRUPO__58B640D31685BC54")
                    .IsUnique();

                entity.Property(e => e.IdGrupo)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("idGrupo");

                entity.Property(e => e.IdGestor).HasColumnName("idGestor");

                entity.Property(e => e.NomeGrupo)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeGrupo");

                entity.HasOne(d => d.IdGestorNavigation)
                    .WithMany(p => p.Grupos)
                    .HasForeignKey(d => d.IdGestor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__GRUPO__idGestor__5AD97420");
            });

            modelBuilder.Entity<Historico>(entity =>
            {
                entity.HasKey(e => e.IdHistorico)
                    .HasName("PK__HISTORIC__6DD36FCFA9A9EBD7");

                entity.ToTable("HISTORICO");

                entity.Property(e => e.IdHistorico).HasColumnName("idHistorico");

                entity.Property(e => e.AtualizadoEm)
                    .HasColumnType("datetime")
                    .HasColumnName("atualizadoEm");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.MediaAvaliacao)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("mediaAvaliacao");

                entity.Property(e => e.NivelSatisfacao)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("nivelSatisfacao");

                entity.Property(e => e.NotaProdutividade)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("notaProdutividade");

                entity.Property(e => e.QtdDeTotalAtividade).HasColumnName("qtdDeTotalAtividade");

                entity.Property(e => e.QtdDeTotalCursos).HasColumnName("qtdDeTotalCursos");

                entity.Property(e => e.QtdDeTotalDescontos).HasColumnName("qtdDeTotalDescontos");

                entity.Property(e => e.SaldoMoeda).HasColumnName("saldoMoeda");

                entity.Property(e => e.Trofeus).HasColumnName("trofeus");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Historicos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__HISTORICO__idUsu__45DE573A");
            });

            modelBuilder.Entity<Localizacao>(entity =>
            {
                entity.HasKey(e => e.IdLocalizacao)
                    .HasName("PK__LOCALIZA__BEC9BF4FC3EEF531");

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
                    .HasConstraintName("FK__LOCALIZAC__idBai__7D63964E");

                entity.HasOne(d => d.IdCepNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdCep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idCep__7C6F7215");

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idCid__7F4BDEC0");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idEst__004002F9");

                entity.HasOne(d => d.IdLogradouroNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdLogradouro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idLog__7E57BA87");
            });

            modelBuilder.Entity<Logradouro>(entity =>
            {
                entity.HasKey(e => e.IdLogradouro)
                    .HasName("PK__LOGRADOU__C2023C431A44CB15");

                entity.ToTable("LOGRADOURO");

                entity.HasIndex(e => e.NomeLogradouro, "UQ__LOGRADOU__9ADBBDF9751DC931")
                    .IsUnique();

                entity.Property(e => e.IdLogradouro).HasColumnName("idLogradouro");

                entity.Property(e => e.NomeLogradouro)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeLogradouro");
            });

            modelBuilder.Entity<Lotacao>(entity =>
            {
                entity.HasKey(e => e.IdLotacçao)
                    .HasName("PK__LOTACAO__9DB7395EB93631BA");

                entity.ToTable("LOTACAO");

                entity.Property(e => e.IdLotacçao).HasColumnName("idLotacçao");

                entity.Property(e => e.IdFuncionario).HasColumnName("idFuncionario");

                entity.Property(e => e.IdGrupo).HasColumnName("idGrupo");

                entity.HasOne(d => d.IdFuncionarioNavigation)
                    .WithMany(p => p.Lotacaos)
                    .HasForeignKey(d => d.IdFuncionario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOTACAO__idFunci__5EAA0504");

                entity.HasOne(d => d.IdGrupoNavigation)
                    .WithMany(p => p.Lotacaos)
                    .HasForeignKey(d => d.IdGrupo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOTACAO__idGrupo__5F9E293D");
            });

            modelBuilder.Entity<Minhasatividade>(entity =>
            {
                entity.HasKey(e => e.IdMinhasAtividades)
                    .HasName("PK__MINHASAT__4679039DF62EA774");

                entity.ToTable("MINHASATIVIDADES");

                entity.Property(e => e.IdMinhasAtividades).HasColumnName("idMinhasAtividades");

                entity.Property(e => e.Anotacoes)
                    .IsRequired()
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

                entity.Property(e => e.IdSituacaoAtividade).HasColumnName("idSituacaoAtividade");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdAtividadeNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idAti__17236851");

                entity.HasOne(d => d.IdSituacaoAtividadeNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdSituacaoAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idSit__190BB0C3");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idUsu__18178C8A");
            });

            modelBuilder.Entity<Registrocurso>(entity =>
            {
                entity.HasKey(e => e.IdRegistroCurso)
                    .HasName("PK__REGISTRO__0FE8B39FFF7C775B");

                entity.ToTable("REGISTROCURSO");

                entity.Property(e => e.IdRegistroCurso).HasColumnName("idRegistroCurso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdSituacaoAtividade).HasColumnName("idSituacaoAtividade");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Registrocursos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROC__idCur__2EFAF1E2");

                entity.HasOne(d => d.IdSituacaoAtividadeNavigation)
                    .WithMany(p => p.Registrocursos)
                    .HasForeignKey(d => d.IdSituacaoAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROC__idSit__30E33A54");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Registrocursos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROC__idUsu__2FEF161B");
            });

            modelBuilder.Entity<Registrodesconto>(entity =>
            {
                entity.HasKey(e => e.IdRegistroDesconto)
                    .HasName("PK__REGISTRO__596321F2967CFDD7");

                entity.ToTable("REGISTRODESCONTO");

                entity.Property(e => e.IdRegistroDesconto).HasColumnName("idRegistroDesconto");

                entity.Property(e => e.IdDesconto).HasColumnName("idDesconto");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdDescontoNavigation)
                    .WithMany(p => p.Registrodescontos)
                    .HasForeignKey(d => d.IdDesconto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROD__idDes__3E3D3572");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Registrodescontos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROD__idUsu__3F3159AB");
            });

            modelBuilder.Entity<Registrominhasunidade>(entity =>
            {
                entity.HasKey(e => e.IdMinhasUnidades)
                    .HasName("PK__REGISTRO__6077D8C1A20804EC");

                entity.ToTable("REGISTROMINHASUNIDADES");

                entity.Property(e => e.IdMinhasUnidades).HasColumnName("idMinhasUnidades");

                entity.Property(e => e.IdUnidadeSenai).HasColumnName("idUnidadeSenai");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdUnidadeSenaiNavigation)
                    .WithMany(p => p.Registrominhasunidades)
                    .HasForeignKey(d => d.IdUnidadeSenai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROM__idUni__4F67C174");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Registrominhasunidades)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROM__idUsu__4E739D3B");
            });

            modelBuilder.Entity<Situacaoatividade>(entity =>
            {
                entity.HasKey(e => e.IdSituacaoAtividade)
                    .HasName("PK__SITUACAO__922A8530D99DBC1C");

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
                    .HasName("PK__TIPOUSUA__03006BFF56298D34");

                entity.ToTable("TIPOUSUARIO");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__TIPOUSUA__A017BD9F9A100DA4")
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
                    .HasName("PK__UNIDADES__EDC820B855BA7CA9");

                entity.ToTable("UNIDADESENAI");

                entity.HasIndex(e => e.NomeUnidadeSenai, "UQ__UNIDADES__940F41B5A926993F")
                    .IsUnique();

                entity.HasIndex(e => e.TelefoneUnidadeSenai, "UQ__UNIDADES__B5490FA4E07A7523")
                    .IsUnique();

                entity.HasIndex(e => e.EmailUnidadeSenai, "UQ__UNIDADES__C4A0ED97DA99A9AD")
                    .IsUnique();

                entity.Property(e => e.IdUnidadeSenai).HasColumnName("idUnidadeSenai");

                entity.Property(e => e.EmailUnidadeSenai)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("emailUnidadeSenai");

                entity.Property(e => e.IdLocalizacao).HasColumnName("idLocalizacao");

                entity.Property(e => e.MediaAvaliacaoUnidadeSenai)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("mediaAvaliacaoUnidadeSenai");

                entity.Property(e => e.MediaProdutividadeUnidadeSenai)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("mediaProdutividadeUnidadeSenai");

                entity.Property(e => e.MediaSatisfacaoUnidadeSenai)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("mediaSatisfacaoUnidadeSenai");

                entity.Property(e => e.NomeUnidadeSenai)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeUnidadeSenai");

                entity.Property(e => e.QtdDeFuncionarios).HasColumnName("qtdDeFuncionarios");

                entity.Property(e => e.QtdFuncionariosAtivos).HasColumnName("qtdFuncionariosAtivos");

                entity.Property(e => e.TelefoneUnidadeSenai)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefoneUnidadeSenai");

                entity.HasOne(d => d.IdLocalizacaoNavigation)
                    .WithMany(p => p.Unidadesenais)
                    .HasForeignKey(d => d.IdLocalizacao)
                    .HasConstraintName("FK__UNIDADESE__idLoc__05F8DC4F");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A67B48C444");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.Email, "UQ__USUARIO__AB6E6164E5DA312F")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__USUARIO__D836E71F8D9C1C37")
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

                entity.Property(e => e.Latitude)
                    .HasColumnType("decimal(16, 14)")
                    .HasColumnName("latitude");

                entity.Property(e => e.Longitude)
                    .HasColumnType("decimal(16, 14)")
                    .HasColumnName("longitude");

                entity.Property(e => e.MedCursosNeg)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("medCursosNeg");

                entity.Property(e => e.MedCursosNeu)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("medCursosNeu");

                entity.Property(e => e.MedCursosPos)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("medCursosPos");

                entity.Property(e => e.MedDescontosNeg)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("medDescontosNeg");

                entity.Property(e => e.MedDescontosNeu)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("medDescontosNeu");

                entity.Property(e => e.MedDescontosPos)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("medDescontosPos");

                entity.Property(e => e.MedFeedbackNeg)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("medFeedbackNeg");

                entity.Property(e => e.MedFeedbackNeu)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("medFeedbackNeu");

                entity.Property(e => e.MedFeedbackPos)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("medFeedbackPos");

                entity.Property(e => e.MedSatisfacaoGeral)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("medSatisfacaoGeral");

                entity.Property(e => e.MediaAvaliacao)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("mediaAvaliacao");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.NotaProdutividade)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("notaProdutividade");

                entity.Property(e => e.SaldoMoeda).HasColumnName("saldoMoeda");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasMaxLength(62)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.Property(e => e.Trofeus).HasColumnName("trofeus");

                entity.Property(e => e.UsuarioAtivo).HasColumnName("usuarioAtivo");

                entity.HasOne(d => d.IdCargoNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdCargo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__idCargo__0CA5D9DE");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__idTipoU__0E8E2250");

                entity.HasOne(d => d.IdUnidadeSenaiNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdUnidadeSenai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__idUnida__0D99FE17");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
