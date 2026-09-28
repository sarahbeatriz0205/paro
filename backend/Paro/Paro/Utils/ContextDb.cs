using global::Paro.Models;
using Microsoft.EntityFrameworkCore;

namespace Paro.Utils
{
        public class ContextDb : DbContext
        {
            public ContextDb(DbContextOptions<ContextDb> options) : base(options)
            {
            }

            public DbSet<Sala> Salas { get; set; }
            public DbSet<Jogador> Jogadores { get; set; }
            public DbSet<Rodada> Rodadas { get; set; }
            public DbSet<Categoria> Categorias { get; set; }
            public DbSet<Usuario> Usuario {get; set;}

            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                base.OnModelCreating(modelBuilder); // sempre chama o base primeiro

                modelBuilder.Entity<Categoria>().HasData(
                    new Categoria { Id = 1, Nome = "Nome" },
                    new Categoria { Id = 2, Nome = "Animal" },
                    new Categoria { Id = 3, Nome = "Fruta" },
                    new Categoria { Id = 4, Nome = "Cor" },
                    new Categoria { Id = 5, Nome = "Objeto" }
                );
            }
        }
}