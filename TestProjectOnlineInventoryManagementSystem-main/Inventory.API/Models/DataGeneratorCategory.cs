using Inventory.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Inventory.API.Models
{
    public class DataGeneratorCategory
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CategoryDBContext(serviceProvider.GetRequiredService<DbContextOptions<CategoryDBContext>>()))
            {
                if (context.Categories.Any())
                {
                    return;
                }

                context.Categories.AddRange(
                                new Category()
                                {
                                    Id = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                                    Name = "Sport"
                                },
                                new Category()
                                {
                                    Id = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                                    Name = "Music"
                                },
                                new Category()
                                {
                                    Id = Guid.Parse("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"),
                                    Name = "HomeAppliance"
                                },
                                new Category()
                                {
                                    Id = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                                    Name = "Furnature"
                                });

                context.SaveChanges();
            }
        }
    }
}