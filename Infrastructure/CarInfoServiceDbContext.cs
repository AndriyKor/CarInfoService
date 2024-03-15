using Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure;

public class CarInfoServiceDbContext : DbContext
{
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }

    public CarInfoServiceDbContext(DbContextOptions<CarInfoServiceDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Brand>().Property(b => b.Name).IsRequired();
        modelBuilder.Entity<Brand>().Property(b => b.Description).IsRequired();
        modelBuilder.Entity<Brand>().Property(b => b.FoundationYear).IsRequired();

        modelBuilder.Entity<Car>().Property(b => b.Description).IsRequired();
        modelBuilder.Entity<Car>().Property(b => b.Model).IsRequired();
        modelBuilder.Entity<Car>().Property(b => b.ProductionYear).IsRequired();

        modelBuilder.Entity<Brand>().HasMany(b => b.Cars).WithOne(c => c.Brand);
    }
}