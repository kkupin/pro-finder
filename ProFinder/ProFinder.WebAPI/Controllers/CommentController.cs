using Microsoft.AspNetCore.Mvc;
using ProFinder.ApplicationCore.DTO;
using ProFinder.ApplicationCore.Interfaces;

namespace ProFinder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;

        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var comments = await _commentService.GetAllAsync();

            return Ok(comments);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var comment = await _commentService.GetByIdAsync(id);

            return Ok(comment);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddCommentDTO addCommentDTO)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Invalid model state");

            await _commentService.AddAsync(addCommentDTO);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateCommentDTO updateCommentDTO)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Invalid model state");

            await _commentService.UpdateAsync(updateCommentDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            await _commentService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}
