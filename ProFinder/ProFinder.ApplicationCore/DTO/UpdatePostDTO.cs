using System.ComponentModel.DataAnnotations;

namespace ProFinder.ApplicationCore.DTO
{
    public class UpdatePostDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public ICollection<Guid> CategoryIds { get; set; }
    }
}
