using global::Auth.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.Data
{
    public class Database : DbContext
    {
        public Database(DbContextOptions<Database> options) : base(options)
        {
        }

        public DbSet<Usuario> Usuario { get; set; }
    }
}