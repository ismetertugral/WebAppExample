using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ViewComponentExampleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
