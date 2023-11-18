using MyBlogProject.DTO;
using MyBlogProject.Entitys;

namespace MyBlogProject.Repo
{
    public class UserRepoImpl : IRepo<UserDTO>
    {
        private SarathContext context = null;

        public UserRepoImpl(SarathContext ctx)
        {
            this.context = ctx;
        }

        public bool Add(UserDTO item)
        {
            User userInfo = new User();
            userInfo.FullName = item.Name;
            userInfo.Email = item.Email;
            userInfo.Password = item.Password;
            userInfo.PhoneNumber = item.PhoneNumber;
            userInfo.UserStatus = item.UserStatus;
            userInfo.RoleId = item.RoleId;
            context.Users.Add(userInfo);
            return true;
        }

        public List<UserDTO> GetAll()
        {
            var Result = context.Users.Select(r => new UserDTO { Id = r.UserId, Name = r.FullName, Email = r.Email, RoleId = r.RoleId, Password = r.Password, PhoneNumber = r.PhoneNumber, UserStatus = r.UserStatus }).ToList();
            return Result;
        }
        public bool Update(int Id, UserDTO item)
        {
            var user = context.Users.FirstOrDefault(u => u.UserId == Id);

            if (user != null)
            {
                user.FullName = item.Name;
                user.Email = item.Email;
                user.Password = item.Password;
                user.PhoneNumber = item.PhoneNumber;
                user.UserStatus = item.UserStatus;
                user.RoleId = item.RoleId;

                context.SaveChanges();
                return true;
            }

            return false;
        }

        public bool Delete(int Id)
        {
            var user = context.Users.FirstOrDefault(u => u.UserId == Id);

            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}