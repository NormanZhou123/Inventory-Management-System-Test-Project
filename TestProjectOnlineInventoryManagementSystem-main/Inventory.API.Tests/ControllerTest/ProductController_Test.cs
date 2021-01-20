using Inventory.API.Controllers;
using Inventory.API.Tests.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Xunit;

namespace Inventory.API.Tests
{
    public class ProductController_Test
    {
        private ProductsController controller;

        public ProductController_Test()
        {
            var fakeProductRepository = new FakeProductRepository();
            var fakeCategoryRepository = new FakeCategoryRepository();

            controller = new ProductsController(fakeProductRepository, fakeCategoryRepository);
        }

        [Fact]
        public async Task Returns_A_View()
        {
            var result = await controller.Index("", "");

            Assert.IsType<IActionResult>(result);
        }
    }
}
