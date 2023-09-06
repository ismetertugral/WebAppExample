using WebApp.Data.Entities;

namespace WebApp.Data.Interfaces
{
    public interface IBlogRepository
    {
        List<Blog> GetAll();

        List<Blog> GetAllWithComment();
    }
}
