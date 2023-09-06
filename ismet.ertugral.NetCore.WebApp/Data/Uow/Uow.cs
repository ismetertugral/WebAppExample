using WebApp.Data.Contexts;
using WebApp.Data.Interfaces;
using WebApp.Data.Repositories;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace WebApp.Data.Uow
{
    public class Uow : IUow
    {
        private readonly MyContext _context;

        public Uow(MyContext context)
        {
            _context = context;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(_context);
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
