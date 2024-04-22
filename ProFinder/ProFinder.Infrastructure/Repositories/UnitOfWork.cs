using ProFinder.Infrastructure.Interfaces;

namespace ProFinder.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;
        private ICategoryRepository _categoryRepository;
        private IPostRepository _postRepository;
        private IReviewRepository _reviewRepository;
        private ICommentRepository _commentRepository;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<int> SaveAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public ICategoryRepository CategoryRepository
        {
            get
            {
                _categoryRepository ??= new CategoryRepository(_dbContext);
                return _categoryRepository;
            }
        }

        public IPostRepository PostRepository
        {
            get
            {
                _postRepository ??= new PostRepository(_dbContext);
                return _postRepository;
            }
        }

        public IReviewRepository ReviewRepository
        {
            get
            {
                _reviewRepository ??= new ReviewRepository(_dbContext);
                return _reviewRepository;
            }
        }

        public ICommentRepository CommentRepository
        {
            get
            {
                _commentRepository ??= new CommentRepository(_dbContext);
                return _commentRepository;
            }
        }

        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
                if (disposing)
                    _dbContext.Dispose();

            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
