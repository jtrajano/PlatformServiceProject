using PlatformService.Core.Models;

namespace PlatformService.Infrastructure.Data
{
    public static class PrepDb
    {
        public static void Prepopulation(this IApplicationBuilder app )
        {
            using (var serviceScope =  app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context) 
        {

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
