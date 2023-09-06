using WebApp.Data.Contexts;
using WebApp.Data.Entities;
using WebApp.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.Controllers
{
    public class ProductController : Controller
    {
        private readonly MyContext _context;

        public ProductController(MyContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Products.Include(x=>x.ProductCategories).ThenInclude(x=>x.Category).ToList());
        }
    }
}
