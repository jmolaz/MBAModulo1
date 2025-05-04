using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MBAModulo1.Core.Models;

namespace MBAModulo1.Core.Data
{
    public class AppDbContext : IdentityDbContext<Vendedor>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed para Categoria
            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { Id = 1, Nome = "Alimentos" },
                new Categoria { Id = 2, Nome = "Bebidas" },
                new Categoria { Id = 3, Nome = "Eletrônicos" }
            );

            // Seed para Produto
            modelBuilder.Entity<Produto>().HasData(
                new Produto { Id = 1, Nome = "Arroz", Preco = 15.50m, CategoriaId = 1 },
                new Produto { Id = 2, Nome = "Refrigerante", Preco = 6.00m, CategoriaId = 2 },
                new Produto { Id = 3, Nome = "Fone de ouvido", Preco = 120.00m, CategoriaId = 3 }
            );
        }
    }
}
