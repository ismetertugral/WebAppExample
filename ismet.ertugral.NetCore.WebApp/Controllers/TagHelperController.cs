using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class TagHelperController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
