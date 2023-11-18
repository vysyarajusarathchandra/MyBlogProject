using System.ComponentModel.DataAnnotations;

namespace MyBlogProject.DTO
{
    public class CategoryDTO
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
