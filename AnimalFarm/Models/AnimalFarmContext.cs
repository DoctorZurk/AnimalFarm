using Microsoft.EntityFrameworkCore;

namespace AnimalFarm.Models
{
    public class AnimalFarmContext : DbContext
    {
        public AnimalFarmContext(DbContextOptions<AnimalFarmContext> options)
            : base(options)
        {
        }
        public DbSet<AnimalFarmItem> AFItems { get; set; }
        public DbSet<AnimalFarmUser> AFUsers { get; set; }
    }
}
