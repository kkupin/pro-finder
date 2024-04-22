using ProFinder.ApplicationCore.DTO;

namespace ProFinder.ApplicationCore.Interfaces
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDTO>> GetAllAsync();
        public Task<CategoryDTO?> GetByIdAsync(Guid id);
        public Task AddAsync(AddCategoryDTO categoryDTO);
        public Task UpdateAsync(UpdateCategoryDTO categoryDTO);
        public Task DeleteByIdAsync(Guid id);
    }
}
