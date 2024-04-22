using ProFinder.Infrastructure.Entities;
using System.ComponentModel.DataAnnotations;

namespace ProFinder.ApplicationCore.DTO
{
    public class AddPostDTO
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public ICollection<Guid> CategoryIds { get; set; }
    }
}
