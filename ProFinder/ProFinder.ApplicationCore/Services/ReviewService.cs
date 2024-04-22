using AutoMapper;
using ProFinder.ApplicationCore.DTO;
using ProFinder.ApplicationCore.Interfaces;
using ProFinder.Infrastructure.Entities;
using ProFinder.Infrastructure.Interfaces;

namespace ProFinder.ApplicationCore.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ReviewService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ReviewDTO>> GetAllAsync()
        {
            var reviews = await _unitOfWork.ReviewRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<ReviewDTO>>(reviews);
        }

        public async Task<ReviewDTO?> GetByIdAsync(Guid id)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(id);
            return _mapper.Map<ReviewDTO>(review);
        }

        public async Task<IEnumerable<CommentDTO>> GetReviewCommentsAsync(Guid id)
        {
            var review = await _unitOfWork.ReviewRepository.GetByIdAsync(id);
            var comments = review?.Comments;

            return _mapper.Map<IEnumerable<CommentDTO>>(comments);
        }

        public async Task AddAsync(AddReviewDTO reviewDTO)
        {
            var review = _mapper.Map<Review>(reviewDTO);
            var isAdded = await _unitOfWork.ReviewRepository.AddAsync(review);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0 && isAdded)
                throw new InvalidOperationException("Failed to add review");
        }

        public async Task UpdateAsync(UpdateReviewDTO reviewDTO)
        {
            var review = _mapper.Map<Review>(reviewDTO);
            var isUpdated = await _unitOfWork.ReviewRepository.UpdateAsync(review);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0 && isUpdated)
                throw new InvalidOperationException("Failed to update review");
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var isDeleted = await _unitOfWork.ReviewRepository.DeleteByIdAsync(id);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0 && isDeleted)
                throw new InvalidOperationException("Failed to delete review");
        }
    }
}
