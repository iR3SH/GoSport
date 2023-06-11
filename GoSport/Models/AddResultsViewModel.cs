using GoSportData.Classes;
using System.ComponentModel;

namespace GoSport.Models
{
    public class AddResultsViewModel
    {
        [DisplayName("Participant")]
        public int IdUser { get; set; }
        [DisplayName("Score du Participant")]
        public string? Score { get; set; }
        [DisplayName("Position du Participant")]
        public int Position { get; set; }
    }
}
