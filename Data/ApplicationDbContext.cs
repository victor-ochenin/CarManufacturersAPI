using Microsoft.EntityFrameworkCore;
using CarManufacturersAPI.Models;

namespace CarManufacturersAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public required DbSet<Manufacturer> Manufacturers { get; set; }
        public required DbSet<Car> Cars { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Car>()
                .HasIndex(c => c.ManufacturerId);

            modelBuilder.Entity<Manufacturer>()
                .HasIndex(m => m.Name)
                .IsUnique();

            modelBuilder.Entity<Car>()
                .HasIndex(c => new { c.Model });

            modelBuilder.Entity<Car>()
                .Property(c => c.Price)
                .HasPrecision(18, 2);
        }
    }
} 