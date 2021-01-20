using Inventory.API.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Linq;

namespace Inventory.API.Models
{
    public class DataGeneratorProduct
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductDBContext(serviceProvider.GetRequiredService<DbContextOptions<ProductDBContext>>()))
            {
                if (context.Products.Any())
                {
                    return;
                }

                context.Products.AddRange(
                                new Product
                                {
                                    Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                                    CategoryId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                                    Name = "Product name 1",
                                    Description = "Product description 1",
                                    UnitPrice = 11,
                                    Quantity = 1
                                },
                                new Product
                                {
                                    Id = Guid.Parse("d8663e5e-7494-4f81-8739-6e0de1bea7ee"),
                                    CategoryId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                                    Name = "Product name 2",
                                    Description = "Product description 2",
                                    UnitPrice = 12,
                                    Quantity = 2
                                },
                                new Product
                                {
                                    Id = Guid.Parse("d173e20d-159e-4127-9ce9-b0ac2564ad97"),
                                    CategoryId = Guid.Parse("da2fd609-d754-4feb-8acd-c4f9ff13ba96"),
                                    Name = "Product name 3",
                                    Description = "Product description 3",
                                    UnitPrice = 13,
                                    Quantity = 13
                                },
                                new Product
                                {
                                    Id = Guid.Parse("493c3228-3444-4a49-9cc0-e8532edc59b2"),
                                    CategoryId = Guid.Parse("24810dfc-2d94-4cc7-aab5-cdf98b83f0c9"),
                                    Name = "Product name 4",
                                    Description = "Product description 4",
                                    UnitPrice = 14,
                                    Quantity = 17
                                },
                                new Product
                                {
                                    Id = Guid.Parse("40ff5488-fdab-45b5-bc3a-14302d59869a"),
                                    CategoryId = Guid.Parse("2902b665-1190-4c70-9915-b9c2d7680450"),
                                    Name = "Product name 5",
                                    Description = "Product description 5",
                                    UnitPrice = 15,
                                    Quantity = 5
                                });

                context.SaveChanges();
            }
        }
    }
}