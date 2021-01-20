using Inventory.API.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.API.Services
{
    public interface IProductRepository
    {
        Task AddProductAsync(Product productToAdd);
        void Dispose();
        Task<IEnumerable<Product>> GetProductsAsync();
        Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId);
        Task<List<Product>> GetProductsByNameAsync(string productName);
        Task<Product> GetProductByIdAsync(Guid productId);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(Product product);
    }
}