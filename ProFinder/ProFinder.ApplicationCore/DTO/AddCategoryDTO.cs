using System.ComponentModel.DataAnnotations;

namespace ProFinder.ApplicationCore.DTO
{
    public class AddCategoryDTO
    {
        [Required]
        public string Name { get; set; }
        public Guid? ParentCategoryId { get; set; }
    }
}
