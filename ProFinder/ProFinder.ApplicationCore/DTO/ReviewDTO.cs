using System.ComponentModel.DataAnnotations;

namespace ProFinder.ApplicationCore.DTO
{
    public class ReviewDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public DateTime PublishedDate { get; set; }
        [Required]
        public string Content { get; set; }
        [Required]
        public Guid PostId { get; set; }
    }
}
