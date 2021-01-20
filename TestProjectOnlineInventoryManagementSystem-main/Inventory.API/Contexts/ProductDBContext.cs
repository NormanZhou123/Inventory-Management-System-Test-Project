using Inventory.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Contexts
{
    public class ProductDBContext: DbContext{
        public ProductDBContext(DbContextOptions<ProductDBContext> options):base(options){

        }

        public DbSet<Product> Products { get; set; }
    }
}