namespace WebApp.Models
{
    public static class ProjectContext
    {
        public static List<Project> Projects = new()
        {
            new Project { Id = 1, Name = "AspNetCore" , Description = "Web Application"},
            new Project { Id = 2, Name = "AspNetCoreMvc", Description = "Mobile"}
        };
    }
}
