using MyBlogProject.Repo;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MyBlogProject.Entitys
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Commentdate { get; set; }
        public string CommentStatus { get; set; }

        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User CommentendUser { get; set; }

        [ForeignKey("Id")]
        public int PostId { get; set; }
        public Post Post { get; set; }

    }
}
