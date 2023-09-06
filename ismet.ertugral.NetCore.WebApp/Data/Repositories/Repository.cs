using WebApp.Data.Contexts;
using WebApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NuGet.Protocol.Core.Types;
using System.Collections;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace WebApp.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : class, new()
    {
        private readonly MyContext _context;

        public Repository(MyContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Set<T>().Add(entity);
            //_context.SaveChanges();
        }

        public void Remove(T entity)
        {
            _context.Set<T>().Remove(entity);
            //_context.SaveChanges();
        }

        public List<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }

        public void Update(T entity)
        {
            _context.Set<T>().Update(entity);
            //_context.SaveChanges();
        }

        public IQueryable<T> GetQueryable()
        {
            return _context.Set<T>().AsQueryable();
        }

        public List<T> GetAllWithInclude()
        {
            var propList = typeof(T).GetProperties()
                .Where(
                   p => (p is not null) && (typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
                && p.PropertyType != typeof(string))
                || p.PropertyType.Namespace == typeof(T).Namespace)
                .Select(p => p.Name).ToArray();

            var List = _context.Set<T>().AsQueryable();
            for (int i = 0; i < propList.Count(); i++)
            {
                List = List.Include(propList[i]);
            }
            return List.ToList();
            //return _context.Set<T>().Include(
            //     typeof(T).GetProperties()
            //    .Where(
            //       p => (typeof(IEnumerable).IsAssignableFrom(p.PropertyType)
            //    && p.PropertyType != typeof(string))
            //    || p.PropertyType.Namespace == typeof(T).Namespace)
            //    .Select(p => p.Name).ToArray()[0]
            //    ).ToList();
        }

        public List<T> GetAllWithInclude(params Expression<Func<T, object>>[] includes)
        {
            var query = _context.Set<T>().AsQueryable<T>();
            if (includes != null)
            {
                query = includes.Aggregate(query,
                          (current, include) => current.Include(include));
            }
            return query.ToList();
        }
    }
}
