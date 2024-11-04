using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using majulicroche.Models;

namespace majulicroche.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para as entidades
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<majulicroche.Models.Cupom> Cupom { get; set; } = default!;
        public DbSet<majulicroche.Models.Fornecedor> Fornecedor { get; set; } = default!;

        public DbSet<Material> Materiais { get; set; }
        public DbSet<ProdutoMaterial> ProdutoMateriais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configuração da chave composta na tabela de junção ProdutoMaterial
            modelBuilder.Entity<ProdutoMaterial>()
                .HasKey(pm => new { pm.ProdutoId, pm.MaterialId });

            modelBuilder.Entity<ProdutoMaterial>()
                .HasOne(pm => pm.Produto)
                .WithMany(p => p.ProdutoMateriais)
                .HasForeignKey(pm => pm.ProdutoId);

            modelBuilder.Entity<ProdutoMaterial>()
                .HasOne(pm => pm.Material)
                .WithMany(m => m.ProdutoMateriais)
                .HasForeignKey(pm => pm.MaterialId);
        }
    }
}
