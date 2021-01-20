using Inventory.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Inventory.API.Contexts
{
    public class CategoryDBContext: DbContext{
        public CategoryDBContext(DbContextOptions<CategoryDBContext> options):base(options){

        }

        public DbSet<Category> Categories { get; set; }
    }
}