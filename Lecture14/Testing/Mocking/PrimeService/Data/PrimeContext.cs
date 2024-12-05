using Microsoft.EntityFrameworkCore;
using Prime.Models;

namespace Prime.Data
{

    public class PrimeDbContext : DbContext
    {
        public virtual DbSet<NumberInfo> Numbers { get; set; } = null!;

        public PrimeDbContext(DbContextOptions<PrimeDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<NumberInfo>()
                .HasKey(n => n.Number);                
        }
    }
}