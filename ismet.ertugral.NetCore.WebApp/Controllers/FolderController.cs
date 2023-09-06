using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class FolderController : Controller
    {
        public IActionResult Index()
        {
            DirectoryInfo folderList = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(),"wwwroot"));
            return View(folderList.GetDirectories());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(string folderName)
        {
            DirectoryInfo folderList = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName));
            if (!folderList.Exists)
            {
                folderList.Create();
            }
            return RedirectToAction("Index");
        }

        public IActionResult Update(string folderName)
        {
            DirectoryInfo folderInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName));
            if (folderInfo.Exists)
            {
                return View(folderInfo);
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Update(string oldFolderName, string newFolderName)
        {
            DirectoryInfo folderInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", oldFolderName));
            if (folderInfo.Exists)
            {
                folderInfo.MoveTo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", newFolderName));
            }
            return RedirectToAction("Index");
        }

        public IActionResult Delete(string folderName)
        {
            DirectoryInfo folderInfo = new DirectoryInfo(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", folderName));
            if (folderInfo.Exists)
            {
                foreach (FileInfo file in folderInfo.GetFiles())
                {
                    file.Delete();
                }
                foreach (DirectoryInfo dir in folderInfo.GetDirectories())
                {
                    dir.Delete(true);
                }
                folderInfo.Delete();
            }
            return RedirectToAction("Index");
        }
    }
}
