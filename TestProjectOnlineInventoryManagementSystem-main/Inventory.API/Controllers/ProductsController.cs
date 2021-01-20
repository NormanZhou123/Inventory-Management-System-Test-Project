using Inventory.API.Models;
using Inventory.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductsController(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        /// <summary>
        /// Get all products, and display them in accordingly order
        /// </summary>
        /// <param name="sortOrder">The order of the sort</param>
        /// <param name="searchString">The key word for filtering</param>
        /// <returns>An ActionResult of type Category</returns>
        public async Task<IActionResult> Index(string sortOrder, string searchString)
        {
            ViewData["QuantitySortParam"] = String.IsNullOrEmpty(sortOrder) ? "quantity_asc" : "";
            var products = await _productRepository.GetProductsAsync();

            if (!String.IsNullOrEmpty(searchString))
            {
                products = products.Where(p => p.Name.ToLower().Contains(searchString.ToLower()));
            }

            switch(sortOrder){
                case "quantity_desc":
                    products = products.OrderByDescending(p => p.Quantity);
                    break;
                case "quantity_asc":
                    products = products.OrderBy(p => p.Quantity);
                    break;
                default:
                    products = products.OrderBy(p => p.Name);
                    break;
            }

            return View(products);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "From [HttpPost]Index: filter on " + searchString;
        }

        /// <summary>
        /// Edit a product
        /// </summary>
        /// <param name="id">The Guid of the product</param>
        /// <returns>An ActionResult of type Product</returns>
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetProductByIdAsync((Guid)id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Edit a product
        /// </summary>
        /// <param name="id">The Guid of the product</param>
        /// <param name="product">The product to be edited</param>
        /// <returns>An ActionResult of type Product</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,UnitPrice,Quantity")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                await _productRepository.UpdateProductAsync(product);

                return RedirectToAction(nameof(Index));
            }

            return View(product);
        }

        /// <summary>
        /// Add a new product
        /// </summary>
        /// <returns>An ActionResult of type Product</returns>
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        /// <summary>
        /// Add a product
        /// </summary>
        /// <param name="product">The product to be added</param>
        /// <returns>Redirect to the Index page</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(Product product)
        {
            product.Id = Guid.NewGuid();
            await _productRepository.AddProductAsync(product);

            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Details of a product
        /// </summary>
        /// <param name="id">The Guid of the product</param>
        /// <returns>The view page of the details of the product</returns>
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetProductByIdAsync((Guid)id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">The Guid of the product</param>
        /// <returns>Redirect to the Index page</returns>
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var product = await _productRepository.GetProductByIdAsync((Guid)id);

            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        /// <summary>
        /// Delete a product
        /// </summary>
        /// <param name="id">The Guid of the product</param>
        /// <returns>Redirect to the Index page</returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            var product = await _productRepository.GetProductByIdAsync((Guid)id);
            await _productRepository.DeleteProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}