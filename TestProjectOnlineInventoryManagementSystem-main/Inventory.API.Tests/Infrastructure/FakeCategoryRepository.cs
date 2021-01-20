using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Inventory.API.Models;
using Inventory.API.Services;

namespace Inventory.API.Tests.Infrastructure
{
    public class FakeCategoryRepository: ICategoryRepository
    {
        public FakeCategoryRepository()
        {
        }

        Task<bool> ICategoryRepository.CategoryExistsAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        void ICategoryRepository.Dispose()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Category>> ICategoryRepository.GetCategoriesAsync()
        {
            throw new NotImplementedException();
        }

        Task<Category> ICategoryRepository.GetCategoryByIdAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        Task<bool> ICategoryRepository.SaveChangesAsync()
        {
            throw new NotImplementedException();
        }

        void ICategoryRepository.UpdateCategory(Category category)
        {
            throw new NotImplementedException();
        }
    }
}
