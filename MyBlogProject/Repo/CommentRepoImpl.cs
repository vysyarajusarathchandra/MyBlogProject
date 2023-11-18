using MyBlogProject.DTO;
using MyBlogProject.Entitys;

namespace MyBlogProject.Repo
{
    public class CommentRepoImpl : IRepo<CommentDTO>
    {
        private SarathContext context = null;

        public CommentRepoImpl(SarathContext ctx)
        {
            this.context = ctx;
        }

        public bool Add(CommentDTO item)
        {
            if (item != null)
            {
                Comment comment = new Comment
                {
                    Text = item.Text,
                    Commentdate = item.Commentdate,
                    CommentStatus = item.CommentStatus,
                    UserId = item.UserId,
                    PostId = item.PostId
                };

                context.Comments.Add(comment);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        public List<CommentDTO> GetAll()
        {
            var comments = context.Comments.Select(c => new CommentDTO
            {
                Id = c.Id,
                Text = c.Text,
                Commentdate = c.Commentdate,
                CommentStatus = c.CommentStatus,
                UserId = c.UserId,
                PostId = c.PostId
            }).ToList();

            return comments;
        }
        public bool Update(int Id, CommentDTO item)
        {
            var existingComment = context.Comments.FirstOrDefault(c => c.Id == Id);

            if (existingComment != null)
            {
                existingComment.Text = item.Text;
                existingComment.Commentdate = item.Commentdate;
                existingComment.CommentStatus = item.CommentStatus;
                existingComment.UserId = item.UserId;
                existingComment.PostId = item.PostId;

                context.SaveChanges();

                return true;
            }

            return false;
        }

        public bool Delete(int Id)
        {
            var deleteComment = context.Comments.FirstOrDefault(c => c.Id == Id);

            if (deleteComment != null)
            {
                context.Comments.Remove(deleteComment);
                context.SaveChanges();

                return true;
            }

            return false;
        }

    }
}
