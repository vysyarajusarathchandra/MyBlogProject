using MyBlogProject.DTO;
using MyBlogProject.Entitys;

namespace MyBlogProject.Repo
{
    public class CategoryRepoImpl : IRepo<CategoryDTO>
    {
        private SarathContext context = null;
        public CategoryRepoImpl(SarathContext ctx)
        {
            context = ctx;
        }
        public bool Add(CategoryDTO item)
        {
            if (item != null)
            {
                Category cat = new Category()
                {
                    CategoryName = item.CategoryName,
                    Description = item.Description
                };

                context.Categories.Add(cat);

                return true;
            }
            return false;
        }

        public List<CategoryDTO> GetAll()
        {

            var Result = context.Categories.Select(c => new CategoryDTO { CategoryId = c.CategoryId, CategoryName = c.CategoryName, Description = c.Description }).ToList();

            return Result;

        }

        public bool Update(int Id, CategoryDTO item)
        {
            var existingCategory = context.Categories.Where(c => c.CategoryId == item.CategoryId).FirstOrDefault();

            if (existingCategory != null)
            {

                existingCategory.CategoryName = item.CategoryName;
                existingCategory.Description = item.Description;
                return true;

            }
            return false;

        }
        public bool Delete(int Id)
        {
            var existingCategory = context.Categories.Where(c => c.CategoryId == Id).FirstOrDefault();

            if (existingCategory != null)
            {
                context.Categories.Remove(existingCategory);
                context.SaveChanges();
                return true;
            }

            return false;
        }

    }

}

