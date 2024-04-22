using Microsoft.AspNetCore.Mvc;
using ProFinder.ApplicationCore.DTO;
using ProFinder.ApplicationCore.Interfaces;

namespace ProFinder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var posts = await _postService.GetAllAsync();

            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var post = await _postService.GetByIdAsync(id);

            return Ok(post);
        }

        [HttpGet("{id}/categories")]
        public async Task<IActionResult> GetPostCategoriesAsync(Guid id)
        {
            var categories = await _postService.GetPostCategoriesAsync(id);

            return Ok(categories);
        }

        [HttpGet("{id}/reviews")]
        public async Task<IActionResult> GetPostReviewsAsync(Guid id)
        {
            var reviews = await _postService.GetPostReviewsAsync(id);

            return Ok(reviews);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddPostDTO addPostDTO)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Invalid model state");

            await _postService.AddAsync(addPostDTO);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdatePostDTO updatePostDTO)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Invalid model state");

            await _postService.UpdateAsync(updatePostDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            await _postService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}
