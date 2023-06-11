using System.ComponentModel.DataAnnotations;

namespace GoSportData.Classes
{
    public class Sports
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
