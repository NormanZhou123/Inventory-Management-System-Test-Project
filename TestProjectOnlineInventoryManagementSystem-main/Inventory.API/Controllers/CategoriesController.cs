using AutoMapper;
using Inventory.API.Models;
using Inventory.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inventory.API.Controllers
{

    [Route("api/v{version:apiVersion}/categories")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryRepository _categoriesRepository;
        private readonly IMapper _mapper;

        public CategoriesController(
            ICategoryRepository categoryRepository,
            IMapper mapper)
        {
            _categoriesRepository = categoryRepository;
            _mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Index()
        {
            var allCategories = await _categoriesRepository.GetCategoriesAsync();
            return View(allCategories);
        }
 
        /// <summary>
        /// Get a list of categorys
        /// </summary>
        /// <returns>An ActionResult of type IEnumerable of Category</returns>
        // [HttpGet]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public async Task<ActionResult<IEnumerable<Category>>> GetCategory()
        // {
        //     var allCategories = await _categoriesRepository.GetCategoriesAsync();
        //     return Ok(_mapper.Map<IEnumerable<Category>>(allCategories));
        // }

        /// <summary>
        /// Get an category by id
        /// </summary>
        /// <param name="categoryId">The id of the category you want to get</param>
        /// <returns>An ActionResult of type Category</returns>
        [HttpGet("{categoryId}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<Category>> GetCategory(
            Guid categoryId)
        {
            var categoryFromRepo = await _categoriesRepository.GetCategoryByIdAsync(categoryId);
            if (categoryFromRepo == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<Category>(categoryFromRepo));
        }

        /// <summary>
        /// Update an Category 
        /// </summary>
        /// <param name="categoryId">The id of the category to update</param>
        /// <param name="categoryForUpdate">The category with updated values</param>
        /// <returns>An ActionResult of type Category</returns>
        /// <response code="422">Validation error</response>
        [HttpPut("{categoryId}")]
        [Consumes("application/json")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity,
            Type = typeof(ValidationProblemDetails))]
        public async Task<ActionResult<Category>> UpdateCategory(
            Guid categoryId,
            Inventory.API.Models.CategoryForUpdate categoryForUpdate)
        {
            var categoryFromRepo = await _categoriesRepository.GetCategoryByIdAsync(categoryId);
            if (categoryFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(categoryForUpdate, categoryFromRepo);

            //// update & save
            _categoriesRepository.UpdateCategory(categoryFromRepo);
            await _categoriesRepository.SaveChangesAsync();

            // return the Category
            return Ok(_mapper.Map<Category>(categoryForUpdate));
        }
    }
}
