namespace WebApp.Data.Entities
{
    public class Blog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        
        public List<Comment> Comments { get; set; }
    } 
}
