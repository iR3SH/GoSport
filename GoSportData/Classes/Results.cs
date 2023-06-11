using System.ComponentModel.DataAnnotations;

namespace GoSportData.Classes
{
    public class Results
    {
        [Key]
        public int Id { get; set; }
        [Key]
        public Users? User { get; set; }
        [Key]
        public Tournaments? Tournament { get; set; }
        public string? Score { get; set; }
        public int Position { get; set; }

    }
}
