using System.ComponentModel.DataAnnotations;

namespace GoSportData.Classes
{
    public class Registrations
    {
        [Key]
        public int Id { get; set; }
        public Users? User { get; set; }
        public Tournaments? Tournament { get; set; }
    }
}
