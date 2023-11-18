namespace MyBlogProject.DTO
{
    public class CommentDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime Commentdate { get; set; }
        public string CommentStatus { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public string UserName { get; set; }

        public string PostTitle { get; set; }


    }
}
