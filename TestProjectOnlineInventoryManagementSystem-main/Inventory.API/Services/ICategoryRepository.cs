using Inventory.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.API.Services
{
    public interface ICategoryRepository
    {
        Task<bool> CategoryExistsAsync(Guid categoryId);
        void Dispose();
        Task<Category> GetCategoryByIdAsync(Guid categoryId);
        Task<IEnumerable<Category>> GetCategoriesAsync();
        Task<bool> SaveChangesAsync();
        void UpdateCategory(Category category);
    }
}