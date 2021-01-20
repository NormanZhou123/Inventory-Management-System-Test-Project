using Inventory.API.Contexts;
using Inventory.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.API.Services
{
    public class CategoryRepository : ICategoryRepository, IDisposable
    { 
        private CategoryDBContext _context;

        public CategoryRepository(CategoryDBContext context)
        {
            _context = context;
        }

        public async Task<bool> CategoryExistsAsync(Guid categoryId)
        {
            return await _context.Categories.AnyAsync(a => a.Id == categoryId);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryByIdAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentException(nameof(categoryId));
            }

            return await _context.Categories
                .FirstOrDefaultAsync(a => a.Id == categoryId);
        }

        public void UpdateCategory(Category category)
        {
            // no code in this implementation
        }

        public async Task<bool> SaveChangesAsync()
        {
            // return true if 1 or more entities were changed
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (_context != null)
                {
                    _context.Dispose();
                    _context = null;
                }
            }
        }
    }
}
