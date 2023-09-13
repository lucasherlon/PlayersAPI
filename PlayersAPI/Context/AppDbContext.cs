using Microsoft.EntityFrameworkCore;

namespace PlayersAPI.Context
{
    public class AppDbContext : DbContext 
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Models.Player> Players { get; set; }
    }
}
