using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class BlogUpdateModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "Maximum 50 karakter olabilir")]
        public string Name { get; set; }
        [Required]
        [MaxLength(200, ErrorMessage = "Maximum 200 karakter olabilir")]
        public string Description { get; set; }
    }
}
