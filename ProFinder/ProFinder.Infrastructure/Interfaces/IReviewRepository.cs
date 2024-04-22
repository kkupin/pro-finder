using ProFinder.Infrastructure.Entities;

namespace ProFinder.Infrastructure.Interfaces
{
    public interface IReviewRepository
    {
        public Task<IEnumerable<Review>> GetAllAsync();
        public Task<Review?> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(Review review);
        public Task<bool> UpdateAsync(Review review);
        public Task<bool> DeleteByIdAsync(Guid id);
    }
}
