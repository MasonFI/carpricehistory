using CarPriceHistory.Domain;
using Microsoft.EntityFrameworkCore;

namespace CarPriceHistory.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<CarMaker> CarMakers { get; set; }
        public DbSet<Car> Cars { get; set; }
    }
}
