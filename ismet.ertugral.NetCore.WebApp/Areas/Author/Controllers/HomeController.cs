using Microsoft.AspNetCore.Mvc;

namespace WebApp.Areas.Author.Controllers
{
    [Area("Author")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
