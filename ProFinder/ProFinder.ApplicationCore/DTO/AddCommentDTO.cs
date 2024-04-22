using System.ComponentModel.DataAnnotations;

namespace ProFinder.ApplicationCore.DTO
{
    public class AddCommentDTO
    {
        [Required]
        public string Body { get; set; }
        [Required]
        public Guid ReviewId { get; set; }
    }
}
