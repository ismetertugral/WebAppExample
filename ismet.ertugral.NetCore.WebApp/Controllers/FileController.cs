using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging;

namespace WebApp.Controllers
{
    public class FileController : Controller
    {
        public IActionResult Index()
        {
            DirectoryInfo fileList = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"));
            return View(fileList.GetFiles("*.*",SearchOption.AllDirectories));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string fileName,string fileContent)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName));
            if (!fileInfo.Exists)
            {
                StreamWriter fileWriter = fileInfo.CreateText();
                fileWriter.Write(fileContent);
                fileWriter.Close();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(string fileName)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName));
            if (fileInfo.Exists)
            {
                return View(fileInfo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(string oldFileName, string newFileName,string fileContent)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldFileName));
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
                fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(),
                                                     "wwwroot",
                                                     path3: Path.GetDirectoryName(oldFileName),
                                                     path4: newFileName));
                StreamWriter fileWriter = fileInfo.CreateText();
                fileWriter.Write(fileContent);
                fileWriter.Close();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string fileName)
        {
            FileInfo fileInfo = new FileInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", fileName));
            if (fileInfo.Exists)
            {
                fileInfo.Delete();
            }
            return RedirectToAction("Index");
        }
    }
}
