namespace MyBlogProject.Repo
{
    public interface IRepo<T>
    {
        List<T> GetAll();
        bool Add(T item);
        bool Update(int Id, T item);
        bool Delete(int Id);
    }
}
