using ProFinder.Infrastructure.Entities;

namespace ProFinder.Infrastructure.Interfaces
{
    public interface IPostRepository
    {
        public Task<IEnumerable<Post>> GetAllAsync();
        public Task<Post?> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(Post post);
        public Task<bool> UpdateAsync(Post post);
        public Task<bool> DeleteByIdAsync(Guid id);
    }
}
