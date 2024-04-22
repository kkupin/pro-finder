using Microsoft.AspNetCore.Mvc;
using ProFinder.ApplicationCore.DTO;
using ProFinder.ApplicationCore.Interfaces;

namespace ProFinder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var categories = await _categoryService.GetAllAsync();

            return Ok(categories);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var category = await _categoryService.GetByIdAsync(id);

            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddCategoryDTO addCategoryDTO)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Invalid model state");

            await _categoryService.AddAsync(addCategoryDTO);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCategoryDTO updateCategoryDTO)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Invalid model state");

            await _categoryService.UpdateAsync(updateCategoryDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            await _categoryService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}
