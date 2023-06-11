using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoSport.Models
{
    public class RegisterViewModel
    {
        [Required]
        [DisplayName("Adresse E-mail")]
        public string? Email { get; set; }
        [Required]
        [DisplayName("Mot de Passe")]
        public string? Password { get; set; }
        [Required]
        [DisplayName("Prénom")]
        public string? FirstName { get; set; }
        [Required]
        [DisplayName("Nom de Famille")]
        public string? LastName { get; set; }
        [Required]
        [DisplayName("Date de Naissance")]
        public DateTime BirthDate { get; set; }
    }
}
