using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class CookieController : Controller
    {
        public IActionResult Index()
        {
            SetCookie();
            ViewData["Cookie"] = GetCookie();
            return View();
        }

        private void SetCookie() =>
            HttpContext.Response.Cookies.Append("Cookie1", "CookieExample", new CookieOptions
            {
                Expires = DateTime.Now.AddDays(1),
                HttpOnly = true,
                SameSite = SameSiteMode.Strict,

            });
       

        private string GetCookie()
        {
            string defCookie = string.Empty;
            HttpContext.Request.Cookies.TryGetValue("Cookie1", out defCookie);
            return defCookie;
        }
    }
}
