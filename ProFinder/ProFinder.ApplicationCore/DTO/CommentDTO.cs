using System.ComponentModel.DataAnnotations;

namespace ProFinder.ApplicationCore.DTO
{
    public class CommentDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Body { get; set; }
        [Required]
        public Guid ReviewId { get; set; }
    }
}