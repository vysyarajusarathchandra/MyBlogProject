using MyBlogProject.DTO;
using MyBlogProject.Entitys;

namespace MyBlogProject.Repo
{
    public class RoleRepoImpl : IRepo<RoleDTO>
    {
        private SarathContext context = null;

        public RoleRepoImpl(SarathContext ctx)
        {
            this.context = ctx;
        }

        public bool Add(RoleDTO item)
        {
            Role roleNew = new Role();
            roleNew.RoleName = item.RoleName;
            context.Roles.Add(roleNew);

            return true;
        }

        public List<RoleDTO> GetAll()
        {
            var Res = context.Roles.Select(r => new RoleDTO { RoleId = r.RoleId, RoleName = r.RoleName }).ToList();
            return Res;
        }

        public bool Update(int Id, RoleDTO item)
        {
            var role = context.Roles.FirstOrDefault(r => r.RoleId == item.RoleId);

            if (role != null)
            {
                role.RoleName = item.RoleName;
                context.SaveChanges();
                return true;
            }

            return false;
        }
        public bool Delete(int Id)
        {
            var role = context.Roles.FirstOrDefault(r => r.RoleId == Id);

            if (role != null)
            {
                context.Roles.Remove(role);
                context.SaveChanges();
                return true;
            }

            return false;
        }
    }
}
