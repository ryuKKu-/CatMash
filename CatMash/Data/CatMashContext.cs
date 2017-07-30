using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CatMash.Data
{
    public class CatMashContext : DbContext
    {
        public CatMashContext(DbContextOptions<CatMashContext> options) : base(options) { }

        public DbSet<Cat> Cats { get; set; }
        public DbSet<History> Histories { get; set; }
        public DbSet<Match> Matches { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
