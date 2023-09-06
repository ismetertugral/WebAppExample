using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApp.Data.Entities
{
    //[Table(name:"Categories",Schema = "dbo")]
    public class Category
    {
        //[Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public List<ProductCategory> ProductCategories { get; set; }
    }
}
