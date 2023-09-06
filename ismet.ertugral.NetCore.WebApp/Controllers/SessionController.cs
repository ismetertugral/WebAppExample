using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class SessionController : Controller
    {
        public IActionResult Index()
        {
            SetSession();
            ViewBag.Session = GetSession();
            return View();
        }

        private string GetSession() => HttpContext.Session.GetString("Session1");

        private void SetSession() => HttpContext.Session.SetString("Session1", "SessionExample");
    }
}
