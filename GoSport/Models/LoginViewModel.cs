using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoSport.Models
{
    public class LoginViewModel
    {
        [Required]
        [DisplayName("Email")]
        public string? Email { get; set; }
        [Required]
        [DisplayName("Mot de Passe")]
        public string? Password { get; set; }
        [Required]
        [DisplayName("Ce souvenir de moi ?")]
        public bool RememberMe { get; set; }
    }
}
