using System.Linq.Expressions;

namespace WebApp.Data.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        void Create(T entity);
        void Remove(T entity);
        List<T> GetAll();
        T GetById(object id);
        void Update(T entity);

        IQueryable<T> GetQueryable();

        List<T> GetAllWithInclude(params Expression<Func<T, object>>[] includes);

        List<T> GetAllWithInclude();
    }
}
