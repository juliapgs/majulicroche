using majulicroche.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace majulicroche.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Carrinho> Carrinhos { get; set; }
        public DbSet<Venda> Vendas { get; set; }
        public DbSet<majulicroche.Models.Cupom> Cupom { get; set; } = default!;
        public DbSet<majulicroche.Models.Fornecedor> Fornecedor { get; set; } = default!;
    }
}
