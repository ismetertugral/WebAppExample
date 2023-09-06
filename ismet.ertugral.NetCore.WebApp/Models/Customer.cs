using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Id Alanı Zorunludur!")]
        [Range(1, int.MaxValue)]
        public int Id { get; set; }
        [Required(ErrorMessage = "FirstName Alanı Zorunludur!")]
        [MaxLength(50,ErrorMessage = "En Fazla 50 karakter olabilir!")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "LastName Alanı Zorunludur!")]
        [MinLength(3, ErrorMessage = "En az 3 karakter olabilir!")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Yaş Alnı Zorunludur!")]
        [Range(18,65, ErrorMessage = "En Fazla 65 En az 18 olabilir!")]
        public int Age { get; set; }
    }
}
