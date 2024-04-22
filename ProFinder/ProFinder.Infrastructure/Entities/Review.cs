namespace ProFinder.Infrastructure.Entities
{
    public class Review
    {
        public Review()
        {
            PublishedDate = DateTime.Now;
        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime PublishedDate { get; set; }
        public string Content { get; set; }

        public Guid PostId { get; set; }
        public Post Post { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
