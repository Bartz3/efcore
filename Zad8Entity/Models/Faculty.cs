using System.ComponentModel.DataAnnotations;

namespace efcore.Models
{
    public class Faculty
    {
        public int ID { get; set; }
        [Display(Name = "Pełna nazwa wydziału")]
        public string name { get; set; }
        [Display(Name = "Skrócona nazwa ywdziału")]
        public string abbr { get; set; }

    }
}
