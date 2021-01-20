using Inventory.API.Contexts;
using Inventory.API.Models;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;

namespace Inventory.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            // migrate the database.  Best practice = in Main, using service scope
            using (var scope = host.Services.CreateScope())
            {
                try
                {
                    var services = scope.ServiceProvider;
                    var contextCategory = services.GetRequiredService<CategoryDBContext>();
                    DataGeneratorCategory.Initialize(services);

                    var contextProduct = services.GetRequiredService<ProductDBContext>();
                    DataGeneratorProduct.Initialize(services);
                }
                catch (Exception ex)
                {
                    var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An error occurred while migrating the database.");
                }
            }

            // run the web app
            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
