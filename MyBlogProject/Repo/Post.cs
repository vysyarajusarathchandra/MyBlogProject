using MyBlogProject.Entitys;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBlogProject.Repo
{
    public class Post
    {

        [Key]
        public int Id { get; set; }

        public string PostTitle { get; set; }
        public string Content { get; set; }
        public string SmallDescription { get; set; }
        public string UrlHandle { get; set; }
        public string PostsStatus { get; set; }
        public DateTime PublishedDate { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User PostedUser { get; set; }

        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
