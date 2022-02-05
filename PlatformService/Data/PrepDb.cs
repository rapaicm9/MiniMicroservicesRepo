using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDb
    {
        public static void PrepPopulation(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }

        private static void SeedData(AppDbContext context)
        {
            if(!context.Platforms.Any())
            {
                Console.WriteLine("--> Seeding Data...");

                context.Platforms.AddRange(
                    new Platform() {Name="DotNet",Publisher="Microsoft",Cost=0},
                    new Platform() {Name="SQL Server Express",Publisher="Microsoft",Cost=0},
                    new Platform() {Name="Kubernetes",Publisher="Cloud Native",Cost=0}
                );
                
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("--> We already have data.");
            }


        }
    }
}