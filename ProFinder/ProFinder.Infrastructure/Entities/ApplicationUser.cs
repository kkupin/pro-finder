using Microsoft.AspNetCore.Identity;

namespace ProFinder.Infrastructure.Entities
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        public ICollection<Review>? Reviews { get; set; }
        public ICollection<Comment>? Comments { get; set; }
    }
}
