using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace GoSportData.Classes
{
    public class Tournaments
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public DateTime Date { get; set; }
        public int MaxUsers { get; set; }
        public Genders? Gender { get; set; }
        public Sports? Sport { get; set; }
        public Users? CreatedBy { get; set; }
        [DefaultValue(false)]
        public bool IsOver { get; set; }
    }
}
