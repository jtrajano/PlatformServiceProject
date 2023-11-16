using Microsoft.EntityFrameworkCore;
using PlatformService.Core.Models;

namespace PlatformService.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base (options)
        {
            
        }
        public DbSet<Platform> Platform { get; set; }

      
    }
}
