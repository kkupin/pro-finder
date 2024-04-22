using AutoMapper;
using ProFinder.ApplicationCore.DTO;
using ProFinder.ApplicationCore.Interfaces;
using ProFinder.Infrastructure.Entities;
using ProFinder.Infrastructure.Interfaces;

namespace ProFinder.ApplicationCore.Services
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CommentDTO>> GetAllAsync()
        {
            var comments = await _unitOfWork.CommentRepository.GetAllAsync();
            return _mapper.Map<IEnumerable<CommentDTO>>(comments);
        }

        public async Task<CommentDTO?> GetByIdAsync(Guid id)
        {
            var comment = await _unitOfWork.CommentRepository.GetByIdAsync(id);
            return _mapper.Map<CommentDTO>(comment);
        }

        public async Task AddAsync(AddCommentDTO commentDTO)
        {
            var comment = _mapper.Map<Comment>(commentDTO);

            //TODO: Get UserId from Identity
            comment.UserId = Guid.NewGuid();

            var isAdded = await _unitOfWork.CommentRepository.AddAsync(comment);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0 && isAdded)
                throw new InvalidOperationException("Failed to add comment");
        }

        public async Task UpdateAsync(UpdateCommentDTO commentDTO)
        {
            var comment = _mapper.Map<Comment>(commentDTO);
            var isUpdated = await _unitOfWork.CommentRepository.UpdateAsync(comment);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0 && isUpdated)
                throw new InvalidOperationException("Failed to update comment");
        }

        public async Task DeleteByIdAsync(Guid id)
        {
            var isDeleted = await _unitOfWork.CommentRepository.DeleteByIdAsync(id);
            var result = await _unitOfWork.SaveAsync();

            if (result == 0 && isDeleted)
                throw new InvalidOperationException("Failed to delete comment");
        }
    }
}
