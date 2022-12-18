using CatalogService.API.Models;
using CatalogService.API.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace CatalogService.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet]
        public ActionResult GetCategories()
        {
            var result = _categoryService.GetCategories();
            return Ok(result);
        }
        [HttpGet("{id}")]
        public ActionResult GetCategory(Guid id)
        {
            var result = _categoryService.GetCategory(id);
            return Ok(result);
        }
        [HttpPost]
        public ActionResult AddCategory(CategoryRequest categoryRequest)
        {
            var result = _categoryService.AddCategory(categoryRequest);
            return CreatedAtAction(nameof(GetCategory), new { id = result.Id }, result);
        }
        [HttpPut]
        public ActionResult UpdateCategory(Guid id, CategoryRequest categoryRequest)
        {
            _categoryService.UpdateCategory(id, categoryRequest);
            return NoContent();
        }
        [HttpDelete("{id}")]
        public ActionResult DeleteCategory(Guid id)
        {
            _categoryService.DeleteCategory(id);
            return NoContent();
        }
    }
}
