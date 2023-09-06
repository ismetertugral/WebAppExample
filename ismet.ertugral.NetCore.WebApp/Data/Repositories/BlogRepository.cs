using WebApp.Data.Contexts;
using WebApp.Data.Entities;
using WebApp.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Data.Repositories
{
    public class BlogRepository(MyContext context) : IBlogRepository
    {
        private readonly MyContext _context = context;

        public List<Blog> GetAll()
        {
            return _context.Blogs.ToList();
        }

        public List<Blog> GetAllWithComment()
        {
            return _context.Blogs.Include(x=>x.Comments).ToList();
        }
    }
}
