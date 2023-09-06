namespace WebApp.Data.Entities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public int BlogId { get; set; }

        public Blog Blog { get; set; }
    }
}
