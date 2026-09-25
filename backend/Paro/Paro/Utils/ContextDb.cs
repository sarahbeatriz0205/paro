using global::Paro.Models;
using Microsoft.EntityFrameworkCore;

namespace Paro.Utils
{
        public class ContextDb : DbContext
        {
            public ContextDb(DbContextOptions<ContextDb> options) : base(options)
            {
            }

            public DbSet<SalaModel> Salas { get; set; }
            public DbSet<JogadorModel> Jogadores { get; set; }
        }
    }