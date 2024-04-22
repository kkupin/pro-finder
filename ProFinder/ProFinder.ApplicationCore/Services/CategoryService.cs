using AutoMapper;
using ProFinder.ApplicationCore.DTO;
using ProFinder.ApplicationCore.Interfaces;
using ProFinder.Infrastructure.Entities;
using ProFinder.Infrastructure.Interfaces;

namespace ProFinder.ApplicationCore.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllAsync()
        {
            var categories = await _unitOfWork.CategoryRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<CategoryDTO?> GetByIdAsync(Guid id)
        {
            var category = await _unitOfWork.CategoryRepository.GetByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task AddAsync(AddCategoryDTO categoryDTO)
        {
            //TODO: Check unique category name
            var category = _mapper.Map<Category>(categoryDTO);
            var isAdded = await _unitOfWork.CategoryRepository.AddAsync(category);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0 && isAdded)
                throw new InvalidOperationException("Failed to add category");
        }

        public async Task UpdateAsync(UpdateCategoryDTO categoryDTO)
        {
            //TODO: Check unique category name
            var category = _mapper.Map<Category>(categoryDTO);
            var isUpdated = await _unitOfWork.CategoryRepository.UpdateAsync(category);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0 && isUpdated)
                throw new InvalidOperationException("Failed to update category");
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var isDeleted = await _unitOfWork.CategoryRepository.DeleteByIdAsync(id);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0 && isDeleted)
                throw new InvalidOperationException("Failed to delete category");
        }
    }
}
