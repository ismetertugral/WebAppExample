using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class StatusController : Controller
    {
        public IActionResult Index(int? code)
        {
            return View(code);
        }

        public IActionResult StatusTest() 
        {
            return RedirectToAction("Empty");
        }
    }
}
