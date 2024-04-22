namespace ProFinder.Infrastructure.Entities
{
    public class Comment
    {
        public Guid Id { get; set; }
        public string Body { get; set; }

        public Guid ReviewId { get; set; }
        public Review Review { get; set; }

        public Guid UserId { get; set; }
        public ApplicationUser User { get; set; }
    }
}
