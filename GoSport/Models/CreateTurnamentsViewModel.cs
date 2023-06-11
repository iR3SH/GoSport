using GoSportData.Classes;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoSport.Models
{
    public class CreateTurnamentsViewModel
    {
        [Required]
        [DisplayName("Tite du Tournoi")]
        public string? Title { get; set; }
        [Required]
        [DisplayName("Date du Début du Tournois")]
        public DateTime? Date { get; set; }
        [Required]
        [DisplayName("Nombre de participant maximum")]
        public int MaxUsers { get; set; }
        [Required]
        [DisplayName("Genres")]
        public int GenderId { get; set; }
        [Required]
        [DisplayName("Sports disponibles")]
        public int? SportId { get; set; }
    }
}
