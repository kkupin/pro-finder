using Microsoft.EntityFrameworkCore;
using ProFinder.Infrastructure.Entities;
using ProFinder.Infrastructure.Interfaces;

namespace ProFinder.Infrastructure.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly AppDbContext _dbContext;

        public PostRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _dbContext.Posts.ToListAsync();
        }

        public async Task<Post?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Posts.Include(p => p.Categories).Include(p => p.Reviews).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<bool> AddAsync(Post post)
        {
            var a = await _dbContext.Posts.AddAsync(post);
            return true;
        }

        public async Task<bool> UpdateAsync(Post post)
        {
            var postToUpdate = await _dbContext.Posts.FirstOrDefaultAsync(c => c.Id == post.Id);
            if (postToUpdate != null)
            {
                _dbContext.Entry(postToUpdate).CurrentValues.SetValues(post);
                return true;
            }
            
            return false;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var postToDelete = await _dbContext.Posts.FindAsync(id);
            if (postToDelete != null)
            {
                _dbContext.Posts.Remove(postToDelete);
                return true;
            }
            
            return false;
        }
    }
}
