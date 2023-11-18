using Microsoft.Extensions.Hosting;
using MyBlogProject.Repo;
using System.ComponentModel.DataAnnotations;

namespace MyBlogProject.Entitys
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Required]
        public string CategoryName { get; set; }

        [Required]
        public string Description { get; set; }

        public virtual ICollection<Post> Posts { get; set; }
    }
}
