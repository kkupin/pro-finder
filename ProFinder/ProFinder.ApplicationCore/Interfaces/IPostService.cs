using ProFinder.ApplicationCore.DTO;

namespace ProFinder.ApplicationCore.Interfaces
{
    public interface IPostService
    {
        public Task<IEnumerable<PostDTO>> GetAllAsync();
        public Task<PostDTO?> GetByIdAsync(Guid id);
        public Task<IEnumerable<CategoryDTO>> GetPostCategoriesAsync(Guid id);
        public Task<IEnumerable<ReviewDTO>> GetPostReviewsAsync(Guid id);
        public Task AddAsync(AddPostDTO postDTO);
        public Task UpdateAsync(UpdatePostDTO postDTO);
        public Task DeleteByIdAsync(Guid id);
    }
}
