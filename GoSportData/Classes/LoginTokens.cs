using System.ComponentModel.DataAnnotations;

namespace GoSportData.Classes
{
    public class LoginTokens
    {
        [Key]
        public int Id { get; set; }
        public string? Token { get; set; }
        public Users? Users { get; set; }
        public DateTime? Expirations { get; set; }
    }
}
