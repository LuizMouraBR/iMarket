using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace iMarket.Models
{
    public partial class iMarketDatabaseContext : DbContext
    {
        public iMarketDatabaseContext()
        {
        }

        public iMarketDatabaseContext(DbContextOptions<iMarketDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CarrinhoDeCompra> CarrinhoDeCompra { get; set; }
        public virtual DbSet<Categoria> Categoria { get; set; }
        public virtual DbSet<Fornecedor> Fornecedor { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=iMarketDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarrinhoDeCompra>(entity =>
            {
                entity.Property(e => e.ProdutoId).HasColumnName("produto_id");

                entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

                entity.HasOne(d => d.Produto)
                    .WithMany(p => p.CarrinhoDeCompra)
                    .HasForeignKey(d => d.ProdutoId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("produto_id");

                entity.HasOne(d => d.Usuario)
                    .WithMany(p => p.CarrinhoDeCompra)
                    .HasForeignKey(d => d.UsuarioId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("usuario_id");
            });

            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Fornecedor>(entity =>
            {
                entity.Property(e => e.Cnpj)
                    .IsRequired()
                    .HasColumnName("cnpj")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Endereco)
                    .IsRequired()
                    .HasColumnName("endereco")
                    .HasMaxLength(10);

                entity.Property(e => e.NomeFantasia)
                    .IsRequired()
                    .HasColumnName("nomeFantasia")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RazaoSocial)
                    .HasColumnName("razaoSocial")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Reputacao).HasColumnName("reputacao");
            });

            modelBuilder.Entity<Produto>(entity =>
            {
                entity.Property(e => e.CategoriaId).HasColumnName("categoria_id");

                entity.Property(e => e.Desconto).HasColumnName("desconto");

                entity.Property(e => e.FornecedorId).HasColumnName("fornecedor_id");

                entity.Property(e => e.Imagem)
                    .HasColumnName("imagem")
                    .IsUnicode(false);

                entity.Property(e => e.Marca)
                    .IsRequired()
                    .HasColumnName("marca")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Preco).HasColumnName("preco");

                entity.HasOne(d => d.Categoria)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.CategoriaId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("categoria_id");

                entity.HasOne(d => d.Fornecedor)
                    .WithMany(p => p.Produto)
                    .HasForeignKey(d => d.FornecedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fornecedor_id");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Nome)
                    .IsRequired()
                    .HasColumnName("nome")
                    .HasMaxLength(70)
                    .IsUnicode(false);

                entity.Property(e => e.Saldo).HasColumnName("saldo");

                entity.Property(e => e.Senha)
                    .IsRequired()
                    .HasColumnName("senha")
                    .HasMaxLength(16)
                    .IsUnicode(false);

                entity.HasOne(d => d.Fornecedor)
                    .WithMany(p => p.Usuario)
                    .HasForeignKey(d => d.FornecedorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("fornecedor_id");
            });
        }
    }
}
