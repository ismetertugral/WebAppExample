using WebApp.Data.Interfaces;

namespace WebApp.Data.Uow
{
    public interface IUow
    {
        IRepository<T> GetRepository<T>() where T : class, new();

        void SaveChanges();
    }
}