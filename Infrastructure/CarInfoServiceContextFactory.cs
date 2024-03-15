using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure;

public class CarInfoServiceContextFactory : IDesignTimeDbContextFactory<CarInfoServiceDbContext>
{
    public CarInfoServiceDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<CarInfoServiceDbContext>();
        optionsBuilder.UseNpgsql("Host=localhost;Port=6544;Database=postgres;Username=postgres;Password=test123");

        return new CarInfoServiceDbContext(optionsBuilder.Options);
    }
}