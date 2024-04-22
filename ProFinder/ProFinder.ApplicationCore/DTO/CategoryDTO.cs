using System.ComponentModel.DataAnnotations;

namespace ProFinder.ApplicationCore.DTO
{
    public class CategoryDTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
