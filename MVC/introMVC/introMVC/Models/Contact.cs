using System.ComponentModel.DataAnnotations;

namespace introMVC.Models
{
    public class Contact
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "İsminizi boş bırakmayın")]
        public string Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage ="Eposta boş olamaz!")]
        public string Email { get; set; }
    }
}
