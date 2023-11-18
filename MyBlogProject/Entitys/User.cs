using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBlogProject.Entitys
{
    public class User
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [StringLength(50)]
        public string FullName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string UserStatus { get; set; }
        [Required]
        public int RoleId { get; set; }
        [ForeignKey(nameof(RoleId))]
        public Role URole { get; set; }

    }
}
