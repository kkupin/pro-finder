using AutoMapper;
using ProFinder.ApplicationCore.DTO;
using ProFinder.ApplicationCore.Interfaces;
using ProFinder.Infrastructure.Entities;
using ProFinder.Infrastructure.Interfaces;

namespace ProFinder.ApplicationCore.Services
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public PostService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //TODO: Add UpdateRating method

        public async Task<IEnumerable<PostDTO>> GetAllAsync()
        {
            var posts = await _unitOfWork.PostRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<PostDTO>>(posts);
        }

        public async Task<PostDTO?> GetByIdAsync(Guid id)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(id);
            return _mapper.Map<PostDTO>(post);
        }

        public async Task<IEnumerable<CategoryDTO>> GetPostCategoriesAsync(Guid id)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(id);
            var categories = post?.Categories;

            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);
        }

        public async Task<IEnumerable<ReviewDTO>> GetPostReviewsAsync(Guid id)
        {
            var post = await _unitOfWork.PostRepository.GetByIdAsync(id);
            var reviews = post?.Reviews;

            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public async Task AddAsync(AddPostDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);

            post.Categories = new List<Category>();
            foreach (var categoryId in postDTO.CategoryIds)
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId);
                if (category != null)
                    post.Categories.Add(category);
            }

            var isAdded = await _unitOfWork.PostRepository.AddAsync(post);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0 && isAdded)
                throw new InvalidOperationException("Failed to add post");
        }

        public async Task UpdateAsync(UpdatePostDTO postDTO)
        {
            var post = _mapper.Map<Post>(postDTO);

            post.Categories = new List<Category>();
            foreach (var categoryId in postDTO.CategoryIds)
            {
                var category = await _unitOfWork.CategoryRepository.GetByIdAsync(categoryId);
                if (category != null)
                    post.Categories.Add(category);
            }

            var isUpdated = await _unitOfWork.PostRepository.UpdateAsync(post);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0 && isUpdated)
                throw new InvalidOperationException("Failed to update post");
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var isDeleted = await _unitOfWork.PostRepository.DeleteByIdAsync(id);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0 && isDeleted)
                throw new InvalidOperationException("Failed to delete post");
        }
    }
}
