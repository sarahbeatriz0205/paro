using global::Paro.Models;
using Microsoft.EntityFrameworkCore;

namespace Paro.Utils
{
        public class AppDbContext : DbContext
        {
            public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
            {
            }

            public DbSet<Sala> Salas { get; set; }
            public DbSet<Jogador> Jogadores { get; set; }
        }
    }