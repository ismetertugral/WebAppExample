using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            IExceptionHandlerPathFeature exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            string logFileName = DateTime.Now.ToString("dd-MM-YYYY_HH-mm-ss-fffffff") + ".txt";
            DirectoryInfo logPathInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "logs"));
            if (!logPathInfo.Exists)
            {
                logPathInfo.Create();
            }
            FileInfo logFileInfo = new FileInfo(Path.Combine(logPathInfo.FullName, logFileName));
            StreamWriter stWriter = logFileInfo.CreateText();
            stWriter.WriteLine("Hata Mesajı : " + exceptionHandlerPathFeature.Error.Message);
            stWriter.WriteLine("Hatanın Gerçekleştiği Yer : " + exceptionHandlerPathFeature.Path);
            stWriter.WriteLine("Hata Değerler : " + string.Join(", ", exceptionHandlerPathFeature.RouteValues.Select(x=>x.Key + ":" + x.Value)));
            if (exceptionHandlerPathFeature.Endpoint != null)
                stWriter.WriteLine("Hata EndPoint : " + exceptionHandlerPathFeature.Endpoint.DisplayName);
            stWriter.Close();
            return View(logFileInfo);
        }

        public IActionResult ErrorTest()
        {
            throw new Exception("Manuel Hata");
        }
    }
}
