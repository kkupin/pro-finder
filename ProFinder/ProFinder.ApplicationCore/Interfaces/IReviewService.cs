using ProFinder.ApplicationCore.DTO;

namespace ProFinder.ApplicationCore.Interfaces
{
    public interface IReviewService
    {
        public Task<IEnumerable<ReviewDTO>> GetAllAsync();
        public Task<ReviewDTO?> GetByIdAsync(Guid id);
        public Task<IEnumerable<CommentDTO>> GetReviewCommentsAsync(Guid id);
        public Task AddAsync(AddReviewDTO reviewDTO);
        public Task UpdateAsync(UpdateReviewDTO reviewDTO);
        public Task DeleteByIdAsync(Guid id);
    }
}
