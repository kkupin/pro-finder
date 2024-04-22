namespace ProFinder.Infrastructure.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public ICategoryRepository CategoryRepository { get; }
        public IPostRepository PostRepository { get; }
        public IReviewRepository ReviewRepository { get; }
        public ICommentRepository CommentRepository { get; }
        public Task<int> SaveAsync();
    }
}
