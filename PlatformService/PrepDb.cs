using Microsoft.EntityFrameworkCore;
using PlatformService.Core.Models;

namespace PlatformService.Infrastructure.Data
{
    public static class PrepDb
    {
        public static void Prepopulation(this IApplicationBuilder app , bool isProd)
        {
            using (var serviceScope =  app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>(), isProd);
            }
        }
        private static void SeedData(AppDbContext context, bool isProd) 
        {
            
            if (isProd)
            {
                Console.WriteLine("--> Using In SQL Db ...");
           
               try
               {
                   Console.WriteLine("--> Attempting to apply migratons...");
                   context.Database.Migrate();
               }
               catch (System.Exception ex)
               {
                    
                   
                     Console.WriteLine($"Migration failed: {ex.Message}");
                   throw;
               }
                

            }
            else
            {
                Console.WriteLine("--> Using In Memory Db ...");
                if (!context.Platform.Any())
                {
                    Console.WriteLine("--> Seeding data ...");
                    context.Platform.AddRange(new List<Platform> {
                        new Platform {Name = "Dot Net", Publisher="Microsoft", Cost = "Free"},
                        new Platform {Name = "SQL Server Express", Publisher="Microsoft", Cost = "Free"},
                        new Platform {Name = "Kubernetes", Publisher="Cloud Native Computing Foundation", Cost = "Free"},

                    });

                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("--> we already have data");

                }

           }

          
        }
    }
}
