using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class GMapController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
