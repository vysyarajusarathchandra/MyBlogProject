using System.ComponentModel.DataAnnotations;

namespace MyBlogProject.Entitys
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }
        [Required]
        public string RoleName { get; set; }
    }
}
