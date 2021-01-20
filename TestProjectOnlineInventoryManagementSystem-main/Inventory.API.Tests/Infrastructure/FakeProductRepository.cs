using Inventory.API.Models;
using Inventory.API.Services;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Inventory.API.Tests.Infrastructure
{
    public class FakeProductRepository : IProductRepository
    {
        public FakeProductRepository()
        {
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            var products = new List<Product>();

            await Task.Run(() => products.Add(new Product() {
                Id = Guid.Parse("5b1c2b4d-48c7-402a-80c3-cc796ad49c6b"),
                CategoryId = Guid.Parse("d28888e9-2ba9-473a-a40f-e38cb54f9b35"),
                Name = "Product name 1",
                Description = "Product description 1",
                UnitPrice = 11,
                Quantity = 1
            }));

            return products;
        }

        Task IProductRepository.AddProductAsync(Product productToAdd)
        {
            throw new NotImplementedException();
        }

        Task IProductRepository.DeleteProductAsync(Product product)
        {
            throw new NotImplementedException();
        }

        void IProductRepository.Dispose()
        {
            throw new NotImplementedException();
        }

        Task<Product> IProductRepository.GetProductByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IProductRepository.GetProductsAsync()
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Product>> IProductRepository.GetProductsByCategoryAsync(Guid categoryId)
        {
            throw new NotImplementedException();
        }

        Task<List<Product>> IProductRepository.GetProductsByNameAsync(string productName)
        {
            throw new NotImplementedException();
        }

        Task IProductRepository.UpdateProductAsync(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
