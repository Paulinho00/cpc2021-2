using Microsoft.EntityFrameworkCore;

namespace KredekTests_Template
{
    public class VehicleDbContext : DbContext
    {
        public DbSet<Vehicle> Vehicles { get; set; }

        public VehicleDbContext(DbContextOptions<VehicleDbContext> options) : base(options)
        {
            
        }
    }
}
