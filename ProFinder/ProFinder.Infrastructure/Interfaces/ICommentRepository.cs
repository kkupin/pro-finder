using ProFinder.Infrastructure.Entities;

namespace ProFinder.Infrastructure.Interfaces
{
    public interface ICommentRepository
    {
        public Task<IEnumerable<Comment>> GetAllAsync();
        public Task<Comment?> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(Comment comment);
        public Task<bool> UpdateAsync(Comment comment);
        public Task<bool> DeleteByIdAsync(Guid id);
    }
}
