using MyBlogProject.DTO;
using MyBlogProject.Entitys;

namespace MyBlogProject.Repo
{
    public class PostRepoImpl : IRepo<PostDTO>
    {
        private SarathContext context = null;

        public PostRepoImpl(SarathContext ctx)
        {
            this.context = ctx;
        }

        public bool Add(PostDTO item)
        {
            if (item != null)
            {
                Post obj = new Post();

                obj.Id = item.Id;
                obj.PostTitle = item.PostTitle;
                obj.Content = item.Content;
                obj.SmallDescription = item.SmallDescription;
                obj.UrlHandle = item.UrlHandle;
                obj.PostsStatus = item.PostsStatus;
                obj.PublishedDate = item.PublishedDate;
                obj.UserId = item.UserId;
                obj.CategoryId = item.CategoryId;

                context.Posts.Add(obj);

                return true;
            }
            return false;
        }

        public List<PostDTO> GetAll()
        {
            var posts = context.Posts.Select(p => new PostDTO
            {
                Id = p.Id,
                PostTitle = p.PostTitle,
                Content = p.Content,
                SmallDescription = p.SmallDescription,
                UrlHandle = p.UrlHandle,
                PostsStatus = p.PostsStatus,
                PublishedDate = p.PublishedDate,
                UserId = p.UserId,
                CategoryId = p.CategoryId,
            }).ToList();

            return posts;
        }

        public bool Update(int Id, PostDTO item)
        {
            var existingPost = context.Posts.FirstOrDefault(p => p.Id == Id);

            if (existingPost != null)
            {
                existingPost.PostTitle = item.PostTitle;
                existingPost.Content = item.Content;
                existingPost.SmallDescription = item.SmallDescription;
                existingPost.UrlHandle = item.UrlHandle;
                existingPost.PostsStatus = item.PostsStatus;
                existingPost.PublishedDate = item.PublishedDate;
                existingPost.UserId = item.UserId;
                existingPost.CategoryId = item.CategoryId;

                context.SaveChanges();

                return true;
            }
            return false;
        }

        public bool Delete(int Id)
        {
            var deletePost = context.Posts.FirstOrDefault(p => p.Id == Id);

            if (deletePost != null)
            {
                context.Posts.Remove(deletePost);
                context.SaveChanges();

                return true;
            }

            return false;
        }

    }
}
