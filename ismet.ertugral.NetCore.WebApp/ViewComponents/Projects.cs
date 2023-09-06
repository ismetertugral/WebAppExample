using WebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ViewComponents
{
    public class Projects : ViewComponent
    {
        public IViewComponentResult Invoke(string numberType = "")
        {
            List<Project> projectList = ProjectContext.Projects;
            switch (numberType)
            {
                case "int": return View(projectList);
                case "byte": return View("ByteType",projectList);
                case "bool": return View("BooleanType", projectList);
                case "string": return View("StringType", projectList);
                default: return View(new List<Project>());
            }
        }

    }
}
