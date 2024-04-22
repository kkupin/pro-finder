using Microsoft.EntityFrameworkCore;
using ProFinder.Infrastructure.Entities;
using ProFinder.Infrastructure.Interfaces;

namespace ProFinder.Infrastructure.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _dbContext;

        public CategoryRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Categories.FindAsync(id);
        }

        public async Task<bool> AddAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            return true;
        }

        public async Task<bool> UpdateAsync(Category category)
        {
            var categoryToUpdate = await _dbContext.Categories.FirstOrDefaultAsync(c => c.Id == category.Id);
            if (categoryToUpdate != null)
            {
                _dbContext.Entry(categoryToUpdate).CurrentValues.SetValues(category);
                return true;
            }
            
            return false;
        }

        public async Task<bool> DeleteByIdAsync(Guid id)
        {
            var categoryToDelete = await _dbContext.Categories.FindAsync(id);
            if (categoryToDelete != null)
            {
                _dbContext.Categories.Remove(categoryToDelete);
                return true;
            }
            
            return false;
        }
    }
}
