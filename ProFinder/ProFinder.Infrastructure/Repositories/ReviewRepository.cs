using Microsoft.EntityFrameworkCore;
using ProFinder.Infrastructure.Entities;
using ProFinder.Infrastructure.Interfaces;

namespace ProFinder.Infrastructure.Repositories
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly AppDbContext _dbContext;

        public ReviewRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Review>> GetAllAsync()
        {
            return await _dbContext.Reviews.ToListAsync();
        }

        public async Task<Review?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Reviews.FindAsync(id);
        }

        public async Task<bool> AddAsync(Review review)
        {
            await _dbContext.Reviews.AddAsync(review);
            return true;
        }

        public async Task<bool> UpdateAsync(Review review)
        {
            var reviewToUpdate = await _dbContext.Reviews.FirstOrDefaultAsync(c => c.Id == review.Id);
            if (reviewToUpdate != null)
            {
                _dbContext.Entry(reviewToUpdate).CurrentValues.SetValues(review);
                return true;
            }
            
            return false;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var reviewToDelete = await _dbContext.Reviews.FindAsync(id);
            if (reviewToDelete != null)
            {
                _dbContext.Reviews.Remove(reviewToDelete);
                return true;
            }
            
            return false;
        }
    }
}
