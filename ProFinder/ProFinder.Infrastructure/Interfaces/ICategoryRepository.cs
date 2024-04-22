using ProFinder.Infrastructure.Entities;

namespace ProFinder.Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {
        public Task<IEnumerable<Category>> GetAllAsync();
        public Task<Category?> GetByIdAsync(Guid id);
        public Task<bool> AddAsync(Category category);
        public Task<bool> UpdateAsync(Category category);
        public Task<bool> DeleteByIdAsync(Guid id);
    }
}
