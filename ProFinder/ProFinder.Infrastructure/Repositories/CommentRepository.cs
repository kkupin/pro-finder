using Microsoft.EntityFrameworkCore;
using ProFinder.Infrastructure.Entities;
using ProFinder.Infrastructure.Interfaces;

namespace ProFinder.Infrastructure.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly AppDbContext _dbContext;

        public CommentRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Comment>> GetAllAsync()
        {
            return await _dbContext.Comments.ToListAsync();
        }

        public async Task<Comment?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Comments.FindAsync(id);
        }

        public async Task<bool> AddAsync(Comment comment)
        {
            await _dbContext.Comments.AddAsync(comment);
            return true;
        }

        public async Task<bool> UpdateAsync(Comment comment)
        {
            var commentToUpdate = await _dbContext.Comments.FirstOrDefaultAsync(c => c.Id == comment.Id);
            if (commentToUpdate != null)
            {
                _dbContext.Entry(commentToUpdate).CurrentValues.SetValues(comment);
                return true;
            }
            
            return false;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var commentToDelete = await _dbContext.Comments.FindAsync(id);
            if (commentToDelete != null)
            {
                _dbContext.Comments.Remove(commentToDelete);
                return true;
            }
            
            return false;
        }
    }
}
