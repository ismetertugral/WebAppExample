using WebApp.Data.Entities;

namespace WebApp.Models
{
    public class ListBlogWithComment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
