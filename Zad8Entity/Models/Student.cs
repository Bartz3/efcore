using System.ComponentModel.DataAnnotations;

namespace efcore.Models
{
    public class Student
    {
        [Key]
        public int id { get; set; }
        [Display(Name = "Imię")]
        [Required]
        public string firstName { get; set; }
        [Display(Name = "Nazwisko")]
        [Required]
        public string lastName { get; set; }

        [Display(Name = "Email")]
        [Required]
        public string email { get; set; }
        [Display(Name = "Numer indeksu")]
        [Required]
        public int sIndex { get; set; }

    }
}
