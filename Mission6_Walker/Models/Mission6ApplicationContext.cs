using Microsoft.EntityFrameworkCore;

namespace Mission6_Walker.Models
{
    public class Mission6ApplicationContext : DbContext
    {
        public Mission6ApplicationContext(DbContextOptions<Mission6ApplicationContext> options) : base (options) 
        { 
        }

        public DbSet<AddMovie> Movies { get; set; }
    }
}
