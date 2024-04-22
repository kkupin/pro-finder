using Microsoft.AspNetCore.Mvc;
using ProFinder.ApplicationCore.DTO;
using ProFinder.ApplicationCore.Interfaces;
using ProFinder.ApplicationCore.Services;

namespace ProFinder.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var reviews = await _reviewService.GetAllAsync();

            return Ok(reviews);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(Guid id)
        {
            var review = await _reviewService.GetByIdAsync(id);

            return Ok(review);
        }

        [HttpGet("{id}/comments")]
        public async Task<IActionResult> GetReviewCommentsAsync(Guid id)
        {
            var comments = await _reviewService.GetReviewCommentsAsync(id);

            return Ok(comments);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(AddReviewDTO addReviewDTO)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Invalid model state");

            await _reviewService.AddAsync(addReviewDTO);

            return NoContent();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(UpdateReviewDTO updateReviewDTO)
        {
            if (!ModelState.IsValid)
                throw new ArgumentException("Invalid model state");

            await _reviewService.UpdateAsync(updateReviewDTO);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteByIdAsync(Guid id)
        {
            await _reviewService.DeleteByIdAsync(id);

            return NoContent();
        }
    }
}
