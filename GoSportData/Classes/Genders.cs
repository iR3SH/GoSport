using System.ComponentModel.DataAnnotations;

namespace GoSportData.Classes
{
    public class Genders
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
