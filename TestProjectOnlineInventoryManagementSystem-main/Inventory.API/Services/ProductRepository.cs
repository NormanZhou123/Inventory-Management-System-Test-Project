using Inventory.API.Contexts;
using Inventory.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Services
{
    public class ProductRepository : IProductRepository, IDisposable
    {
        private ProductDBContext _context;

        public ProductRepository(ProductDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _context.Products.ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetProductsByCategoryAsync(Guid categoryId)
        {
            if (categoryId == Guid.Empty)
            {
                throw new ArgumentException(nameof(categoryId));
            }

            return await _context.Products
                .Include(b => b.Category)
                .Where(b => b.CategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<Product> GetProductByIdAsync(Guid productId)
        {
            if (productId == Guid.Empty)
            {
                throw new ArgumentException(nameof(productId));
            }

            return await _context.Products
                .Where(b => b.Id == productId)
                .FirstOrDefaultAsync();
        }

        public async Task<Product> GetProductByNameAsync(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentException(nameof(productName));
            }

            return await _context.Products
                .Where(b => b.Name == productName)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Product>> GetProductsByNameAsync(string productName)
        {
            if (string.IsNullOrEmpty(productName))
            {
                throw new ArgumentException(nameof(productName));
            }

            return await _context.Products
                .Where(p => p.Name.Contains(productName))
                .ToListAsync();
        }

        public async Task UpdateProductAsync(Product product)
        {
            if (product != null)
            {
                _context.Products.Update(product);
                await _context.SaveChangesAsync();
            }
        }

        public async Task AddProductAsync(Product productToAdd)
        {
            if (productToAdd == null)
            {
                throw new ArgumentNullException(nameof(productToAdd));
            }

            try{
                await _context.Products.AddAsync(productToAdd);
                await SaveChangesAsync();
            }catch(Exception exception){
                throw exception;
            }
        }

        public async Task DeleteProductAsync(Product product)
        {
            if (product != null)
            {
                _context.Products.Remove(product);
                await SaveChangesAsync();
            }
        }

        private async Task<bool> SaveChangesAsync()
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
