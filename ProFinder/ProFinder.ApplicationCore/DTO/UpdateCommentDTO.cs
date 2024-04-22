using System.ComponentModel.DataAnnotations;

namespace ProFinder.ApplicationCore.DTO
{
    public class UpdateCommentDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Body { get; set; }
    }
}
