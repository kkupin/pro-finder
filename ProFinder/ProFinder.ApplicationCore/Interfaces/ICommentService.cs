using ProFinder.ApplicationCore.DTO;

namespace ProFinder.ApplicationCore.Interfaces
{
    public interface ICommentService
    {
        public Task<IEnumerable<CommentDTO>> GetAllAsync();
        public Task<CommentDTO?> GetByIdAsync(Guid id);
        public Task AddAsync(AddCommentDTO commentDTO);
        public Task UpdateAsync(UpdateCommentDTO commentDTO);
        public Task DeleteByIdAsync(Guid id);
    }
}
