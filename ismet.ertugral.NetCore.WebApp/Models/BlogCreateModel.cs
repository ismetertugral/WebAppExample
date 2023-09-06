using WebApp.Data.Entities;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebApp.Models
{
    public class BlogCreateModel
    {
        [Required]
        [MaxLength(50,ErrorMessage = "Maximum 50 karakter olabilir")]
        public string Name { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Maximum 200 karakter olabilir")]
        public string Description { get; set; }
    }
}
