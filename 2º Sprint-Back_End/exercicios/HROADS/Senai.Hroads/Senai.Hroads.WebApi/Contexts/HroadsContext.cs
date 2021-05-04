using Microsoft.EntityFrameworkCore;
using Senai.Hroads.WebApi.Domains;

#nullable disable

namespace Senai.Hroads.WebApi.Contexts {
    public partial class HroadsContext : DbContext {
        public HroadsContext() {
        }

        public HroadsContext(DbContextOptions<HroadsContext> options)
            : base(options) {
        }

        public virtual DbSet<Classe> Classes { get; set; }
        public virtual DbSet<ClasseHabilidade> ClasseHabilidades { get; set; }
        public virtual DbSet<Habilidade> Habilidades { get; set; }
        public virtual DbSet<Personagem> Personagems { get; set; }
        public virtual DbSet<TipoHabilidade> TipoHabilidades { get; set; }
        public virtual DbSet<TipoUsuario> TipoUsuarios { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            if(!optionsBuilder.IsConfigured) {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=CELSO-PC; initial catalog=Senai_Hroads_Manha; user Id=sa; pwd=7895123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Classe>(entity => {
                entity.HasKey(e => e.IdClasse);

                entity.ToTable("Classe");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.Nome)
                    .HasMaxLength(35)
                    .IsUnicode(false)
                    .HasColumnName("nome");
            });

            modelBuilder.Entity<ClasseHabilidade>(entity => {
                entity.HasKey(e => e.IdClasseHabilidade)
                    .HasName("PK_ClasseHabilidade");

                entity.ToTable("Classe_Habilidade");

                entity.Property(e => e.IdClasseHabilidade).HasColumnName("idClasseHabilidade");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.ClasseHabilidades)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK_Classe");

                entity.HasOne(d => d.IdHabilidadeNavigation)
                    .WithMany(p => p.ClasseHabilidades)
                    .HasForeignKey(d => d.IdHabilidade)
                    .HasConstraintName("FK_Habilidade");
            });

            modelBuilder.Entity<Habilidade>(entity => {
                entity.HasKey(e => e.IdHabilidade);

                entity.ToTable("Habilidade");

                entity.Property(e => e.IdHabilidade).HasColumnName("idHabilidade");

                entity.Property(e => e.IdTipoHabilidade).HasColumnName("idTipoHabilidade");

                entity.Property(e => e.Nome)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.HasOne(d => d.IdTipoHabilidadeNavigation)
                    .WithMany(p => p.Habilidades)
                    .HasForeignKey(d => d.IdTipoHabilidade)
                    .HasConstraintName("FK_TipoHabilidade_Habilidade");
            });

            modelBuilder.Entity<Personagem>(entity => {
                entity.HasKey(e => e.IdPersonagem);

                entity.ToTable("Personagem");

                entity.Property(e => e.IdPersonagem).HasColumnName("idPersonagem");

                entity.Property(e => e.DtAtualizacao)
                    .HasColumnType("date")
                    .HasColumnName("dtAtualizacao");

                entity.Property(e => e.DtCricao)
                    .HasColumnType("date")
                    .HasColumnName("dtCricao");

                entity.Property(e => e.IdClasse).HasColumnName("idClasse");

                entity.Property(e => e.Mana)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("mana");

                entity.Property(e => e.Nome)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("nome");

                entity.Property(e => e.Vida)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("vida");

                entity.HasOne(d => d.IdClasseNavigation)
                    .WithMany(p => p.Personagems)
                    .HasForeignKey(d => d.IdClasse)
                    .HasConstraintName("FK_Classe_Personagem");
            });

            modelBuilder.Entity<TipoHabilidade>(entity => {
                entity.HasKey(e => e.IdTipoHabilidade);

                entity.ToTable("TipoHabilidade");

                entity.Property(e => e.IdTipoHabilidade).HasColumnName("idTipoHabilidade");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<TipoUsuario>(entity => {
                entity.HasKey(e => e.IdTipoUsuario);

                entity.ToTable("TipoUsuario");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Tipo)
                    .HasMaxLength(25)
                    .IsUnicode(false)
                    .HasColumnName("tipo");
            });

            modelBuilder.Entity<Usuario>(entity => {
                entity.HasKey(e => e.IdUsuario);

                entity.ToTable("Usuario");

                entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.IdTipoUsuario).HasColumnName("idTipoUsuario");

                entity.Property(e => e.Senha)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("senha");

                entity.HasOne(d => d.IdTipoUsuarioNavigation)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(d => d.IdTipoUsuario)
                    .HasConstraintName("FK_TipoUsuario_PK_Usuario");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
