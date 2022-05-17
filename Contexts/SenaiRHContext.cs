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
                    .HasName("PK__ATIVIDAD__E6E8EAE2CA074861");

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

                entity.Property(e => e.Equipe).HasColumnName("equipe");

                entity.Property(e => e.IdGestorCadastro).HasColumnName("idGestorCadastro");

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
                    .HasConstraintName("FK__ATIVIDADE__idGes__093F5D4E");
            });

            modelBuilder.Entity<Avaliacaounidadesenai>(entity =>
            {
                entity.HasKey(e => e.IdAvalicaoUnidadeSenai)
                    .HasName("PK__AVALIACA__BA46550F6001E604");

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
                    .HasConstraintName("FK__AVALIACAO__idUni__0A338187");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Avaliacaounidadesenais)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AVALIACAO__idUsu__0B27A5C0");
            });

            modelBuilder.Entity<Avaliacaousuario>(entity =>
            {
                entity.HasKey(e => e.IdAvaliacaoUsuario)
                    .HasName("PK__AVALIACA__08B8D2857B5FF132");

                entity.ToTable("AVALIACAOUSUARIO");

                entity.Property(e => e.IdAvaliacaoUsuario).HasColumnName("idAvaliacaoUsuario");

                entity.Property(e => e.Avaliacao)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("avaliacao");

                entity.Property(e => e.IdUsuarioAvaliado).HasColumnName("idUsuarioAvaliado");

                entity.Property(e => e.IdUsuarioAvaliador).HasColumnName("idUsuarioAvaliador");

                entity.HasOne(d => d.IdUsuarioAvaliadoNavigation)
                    .WithMany(p => p.AvaliacaousuarioIdUsuarioAvaliadoNavigations)
                    .HasForeignKey(d => d.IdUsuarioAvaliado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AVALIACAO__idUsu__0C1BC9F9");

                entity.HasOne(d => d.IdUsuarioAvaliadorNavigation)
                    .WithMany(p => p.AvaliacaousuarioIdUsuarioAvaliadorNavigations)
                    .HasForeignKey(d => d.IdUsuarioAvaliador)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__AVALIACAO__idUsu__0D0FEE32");
            });

            modelBuilder.Entity<Bairro>(entity =>
            {
                entity.HasKey(e => e.IdBairro)
                    .HasName("PK__BAIRRO__86B592A13D64C9B1");

                entity.ToTable("BAIRRO");

                entity.HasIndex(e => e.NomeBairro, "UQ__BAIRRO__72D4FAEC9E27D708")
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
                    .HasName("PK__CARGO__3D0E29B8478C6E1A");

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
                    .HasConstraintName("FK__CARGO__idSetor__0E04126B");
            });

            modelBuilder.Entity<Cep>(entity =>
            {
                entity.HasKey(e => e.IdCep)
                    .HasName("PK__CEP__398F6FDA9C0E7590");

                entity.ToTable("CEP");

                entity.HasIndex(e => e.Cep1, "UQ__CEP__D83671A59B9CCE6E")
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
                    .HasName("PK__CIDADE__559AD0FE2E99E53B");

                entity.ToTable("CIDADE");

                entity.HasIndex(e => e.NomeCidade, "UQ__CIDADE__FF0A5458F612560E")
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
                    .HasName("PK__COMENTAR__71861C41BC9B3E34");

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
                    .HasConstraintName("FK__COMENTARI__idCur__4EDDB18F");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentariocursos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMENTARI__idUsu__4FD1D5C8");
            });

            modelBuilder.Entity<Comentariodesconto>(entity =>
            {
                entity.HasKey(e => e.IdComentarioDesconto)
                    .HasName("PK__COMENTAR__E9D05157CCB7F840");

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
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("negativo");

                entity.Property(e => e.Neutro)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("neutro");

                entity.Property(e => e.Positivo)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("positivo");

                entity.HasOne(d => d.IdDescontoNavigation)
                    .WithMany(p => p.Comentariodescontos)
                    .HasForeignKey(d => d.IdDesconto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMENTARI__idDes__10E07F16");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Comentariodescontos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__COMENTARI__idUsu__11D4A34F");
            });

            modelBuilder.Entity<Curso>(entity =>
            {
                entity.HasKey(e => e.IdCurso)
                    .HasName("PK__CURSO__8551ED055608F00A");

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
                    .HasConstraintName("FK__CURSO__idEmpresa__4B0D20AB");

                entity.HasOne(d => d.IdSituacaoInscricaoNavigation)
                    .WithMany(p => p.Cursos)
                    .HasForeignKey(d => d.IdSituacaoInscricao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSO__idSituaca__4C0144E4");
            });

            modelBuilder.Entity<Cursofavorito>(entity =>
            {
                entity.HasKey(e => e.IdCursoFavorito)
                    .HasName("PK__CURSOFAV__B7680EB14CD38EC8");

                entity.ToTable("CURSOFAVORITO");

                entity.Property(e => e.IdCursoFavorito).HasColumnName("idCursoFavorito");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Cursofavoritos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSOFAVO__idCur__567ED357");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Cursofavoritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CURSOFAVO__idUsu__5772F790");
            });

            modelBuilder.Entity<Decisao>(entity =>
            {
                entity.HasKey(e => e.IdDecisao)
                    .HasName("PK__DECISAO__181085E6F8D43717");

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
                    .HasConstraintName("FK__DECISAO__idUsuar__1699586C");
            });

            modelBuilder.Entity<Desconto>(entity =>
            {
                entity.HasKey(e => e.IdDesconto)
                    .HasName("PK__DESCONTO__3D5D117A4B287D82");

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
                    .HasConstraintName("FK__DESCONTO__idEmpr__178D7CA5");
            });

            modelBuilder.Entity<Descontofavorito>(entity =>
            {
                entity.HasKey(e => e.IdDescontoFavorito)
                    .HasName("PK__DESCONTO__AE1CB35AEE5C6C16");

                entity.ToTable("DESCONTOFAVORITO");

                entity.Property(e => e.IdDescontoFavorito).HasColumnName("idDescontoFavorito");

                entity.Property(e => e.IdDesconto).HasColumnName("idDesconto");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdDescontoNavigation)
                    .WithMany(p => p.Descontofavoritos)
                    .HasForeignKey(d => d.IdDesconto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DESCONTOF__idDes__1881A0DE");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Descontofavoritos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__DESCONTOF__idUsu__1975C517");
            });

            modelBuilder.Entity<Empresa>(entity =>
            {
                entity.HasKey(e => e.IdEmpresa)
                    .HasName("PK__EMPRESA__75D2CED4DA0A01BC");

                entity.ToTable("EMPRESA");

                entity.HasIndex(e => e.EmailEmpresa, "UQ__EMPRESA__440803BD1EF539F7")
                    .IsUnique();

                entity.HasIndex(e => e.TelefoneEmpresa, "UQ__EMPRESA__8FB435A9C0A3B9B4")
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
                    .HasConstraintName("FK__EMPRESA__idLocal__1A69E950");
            });

            modelBuilder.Entity<Estado>(entity =>
            {
                entity.HasKey(e => e.IdEstado)
                    .HasName("PK__ESTADO__62EA894A3201609F");

                entity.ToTable("ESTADO");

                entity.HasIndex(e => e.NomeEstado, "UQ__ESTADO__20DB075B41547779")
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
                    .HasName("PK__FEEDBACK__535470E928B97C50");

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
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("negativo");

                entity.Property(e => e.Neutro)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("neutro");

                entity.Property(e => e.Positivo)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("positivo");

                entity.Property(e => e.ValorMoedas).HasColumnName("valorMoedas");

                entity.HasOne(d => d.IdDecisaoNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.IdDecisao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FEEDBACK__idDeci__1B5E0D89");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Feedbacks)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__FEEDBACK__idUsua__1C5231C2");
            });

            modelBuilder.Entity<Localizacao>(entity =>
            {
                entity.HasKey(e => e.IdLocalizacao)
                    .HasName("PK__LOCALIZA__BEC9BF4F848DCE23");

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
                    .HasConstraintName("FK__LOCALIZAC__idBai__1D4655FB");

                entity.HasOne(d => d.IdCepNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdCep)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idCep__1E3A7A34");

                entity.HasOne(d => d.IdCidadeNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdCidade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idCid__1F2E9E6D");

                entity.HasOne(d => d.IdEstadoNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdEstado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idEst__2022C2A6");

                entity.HasOne(d => d.IdLogradouroNavigation)
                    .WithMany(p => p.Localizacaos)
                    .HasForeignKey(d => d.IdLogradouro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__LOCALIZAC__idLog__2116E6DF");
            });

            modelBuilder.Entity<Logradouro>(entity =>
            {
                entity.HasKey(e => e.IdLogradouro)
                    .HasName("PK__LOGRADOU__C2023C439EA49F40");

                entity.ToTable("LOGRADOURO");

                entity.HasIndex(e => e.NomeLogradouro, "UQ__LOGRADOU__9ADBBDF94519916B")
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
                    .HasName("PK__MINHASAT__4679039D330445E3");

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

                entity.Property(e => e.IdSetor).HasColumnName("idSetor");

                entity.Property(e => e.IdSituacaoAtividade).HasColumnName("idSituacaoAtividade");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdAtividadeNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idAti__220B0B18");

                entity.HasOne(d => d.IdSetorNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdSetor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idSet__22FF2F51");

                entity.HasOne(d => d.IdSituacaoAtividadeNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdSituacaoAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idSit__23F3538A");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Minhasatividades)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__MINHASATI__idUsu__24E777C3");
            });

            modelBuilder.Entity<Registrocurso>(entity =>
            {
                entity.HasKey(e => e.IdRegistroCurso)
                    .HasName("PK__REGISTRO__0FE8B39F7D1A3F7A");

                entity.ToTable("REGISTROCURSO");

                entity.Property(e => e.IdRegistroCurso).HasColumnName("idRegistroCurso");

                entity.Property(e => e.IdCurso).HasColumnName("idCurso");

                entity.Property(e => e.IdSituacaoAtividade).HasColumnName("idSituacaoAtividade");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdCursoNavigation)
                    .WithMany(p => p.Registrocursos)
                    .HasForeignKey(d => d.IdCurso)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROC__idCur__5A4F643B");

                entity.HasOne(d => d.IdSituacaoAtividadeNavigation)
                    .WithMany(p => p.Registrocursos)
                    .HasForeignKey(d => d.IdSituacaoAtividade)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROC__idSit__5C37ACAD");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Registrocursos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROC__idUsu__5B438874");
            });

            modelBuilder.Entity<Registrodesconto>(entity =>
            {
                entity.HasKey(e => e.IdRegistroDesconto)
                    .HasName("PK__REGISTRO__596321F210CB7E70");

                entity.ToTable("REGISTRODESCONTO");

                entity.Property(e => e.IdRegistroDesconto).HasColumnName("idRegistroDesconto");

                entity.Property(e => e.IdDesconto).HasColumnName("idDesconto");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.HasOne(d => d.IdDescontoNavigation)
                    .WithMany(p => p.Registrodescontos)
                    .HasForeignKey(d => d.IdDesconto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROD__idDes__28B808A7");

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.Registrodescontos)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__REGISTROD__idUsu__29AC2CE0");
            });

            modelBuilder.Entity<Setor>(entity =>
            {
                entity.HasKey(e => e.IdSetor)
                    .HasName("PK__SETOR__A3780105C6D31EB6");

                entity.ToTable("SETOR");

                entity.HasIndex(e => e.NomeSetor, "UQ__SETOR__DD7E5C8B81B2AA7E")
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
                    .HasName("PK__SITUACAO__922A8530884609DD");

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
                    .HasName("PK__TIPOUSUA__03006BFFC64A3E8D");

                entity.ToTable("TIPOUSUARIO");

                entity.HasIndex(e => e.NomeTipoUsuario, "UQ__TIPOUSUA__A017BD9F0F6AB634")
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
                    .HasName("PK__UNIDADES__EDC820B8A759DEAD");

                entity.ToTable("UNIDADESENAI");

                entity.HasIndex(e => e.NomeUnidadeSenai, "UQ__UNIDADES__940F41B5E4BD8514")
                    .IsUnique();

                entity.HasIndex(e => e.TelefoneUnidadeSenai, "UQ__UNIDADES__B5490FA4EA937B44")
                    .IsUnique();

                entity.HasIndex(e => e.EmailUnidadeSenai, "UQ__UNIDADES__C4A0ED97310FC98F")
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

                entity.Property(e => e.Negativo)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("negativo");

                entity.Property(e => e.Neutro)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("neutro");

                entity.Property(e => e.NomeUnidadeSenai)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("nomeUnidadeSenai");

                entity.Property(e => e.NotaProdutividade).HasColumnType("decimal(2, 1)");

                entity.Property(e => e.Positive)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("positive");

                entity.Property(e => e.TelefoneUnidadeSenai)
                    .IsRequired()
                    .HasMaxLength(13)
                    .IsUnicode(false)
                    .HasColumnName("telefoneUnidadeSenai");

                entity.HasOne(d => d.IdLocalizacaoNavigation)
                    .WithMany(p => p.Unidadesenais)
                    .HasForeignKey(d => d.IdLocalizacao)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__UNIDADESE__idLoc__2AA05119");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(e => e.IdUsuario)
                    .HasName("PK__USUARIO__645723A6C558DB14");

                entity.ToTable("USUARIO");

                entity.HasIndex(e => e.CaminhoFotoPerfil, "UQ__USUARIO__863E7F42344BDBA3")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__USUARIO__AB6E61645C828E73")
                    .IsUnique();

                entity.HasIndex(e => e.Cpf, "UQ__USUARIO__D836E71FC4BB5C9F")
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

                entity.Property(e => e.MediaAvaliacao)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("mediaAvaliacao");

                entity.Property(e => e.Negativo)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("negativo");

                entity.Property(e => e.Neutro)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("neutro");

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.NotaProdutividade)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("notaProdutividade");

                entity.Property(e => e.Positivo)
                    .HasColumnType("decimal(2, 1)")
                    .HasColumnName("positivo");

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
                    .HasConstraintName("FK__USUARIO__idCargo__2B947552");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__idTipoU__2C88998B");

                entity.HasOne(d => d.IdUnidadeSenaiNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdUnidadeSenai)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__USUARIO__idUnida__2D7CBDC4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
