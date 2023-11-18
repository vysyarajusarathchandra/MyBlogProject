using MyBlogProject.Entitys;

namespace MyBlogProject.Repo
{
    public class UnitOfWork
    {
        SarathContext context = null;
        CategoryRepoImpl CategoryRepoImpl = null;
        RoleRepoImpl RoleRepoImpl = null;
        UserRepoImpl UserRepoImpl = null;
        PostRepoImpl PostRepoImpl = null;
        CommentRepoImpl CommentRepoImpl = null;
        public UnitOfWork(SarathContext ctx)
        {
            context = ctx;
        }
        public CategoryRepoImpl CategoryImplObject
        {
            get
            {
                if (CategoryRepoImpl == null)
                {
                    CategoryRepoImpl = new CategoryRepoImpl(context);
                }
                return CategoryRepoImpl;
            }

        }
        public RoleRepoImpl RoleImplObject
        {
            get
            {
                if (RoleRepoImpl == null)
                {
                    RoleRepoImpl = new RoleRepoImpl(context);
                }
                return RoleRepoImpl;
            }
        }

        public UserRepoImpl UserImplObject
        {
            get
            {
                if (UserRepoImpl == null)
                {
                    UserRepoImpl = new UserRepoImpl(context);

                }
                return UserRepoImpl;
            }
        }

        public PostRepoImpl PostImplObject
        {
            get
            {
                if (PostRepoImpl == null)
                {
                    PostRepoImpl = new PostRepoImpl(context);

                }
                return PostRepoImpl;
            }
        }
        public CommentRepoImpl CommentImplObject
        {
            get
            {
                if (CommentRepoImpl == null)
                {
                    CommentRepoImpl = new CommentRepoImpl(context);

                }
                return CommentRepoImpl;
            }
        }
        public void SaveAll()
        {
            if (context != null)
            {

                context.SaveChanges();
            }
        }
    }
}

