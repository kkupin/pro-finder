namespace ProFinder.Infrastructure.Entities
{
    public class Post
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public float Rating { get; set; }

        public ICollection<Category> Categories { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
