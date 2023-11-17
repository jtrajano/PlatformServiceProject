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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{


        //   modelBuilder.Entity<Platform>().HasData(

        //            new Platform {Id = 1, Name = "Dot Net", Publisher="Microsoft", Cost = "Free"},
        //                new Platform {Id = 2, Name = "SQL Server Express", Publisher="Microsoft", Cost = "Free"},
        //                new Platform {Id = 3, Name = "Kubernetes", Publisher="Cloud Native Computing Foundation", Cost = "Free"}



        //        );

         


        //    base.OnModelCreating(modelBuilder);
        //}


    }
}
