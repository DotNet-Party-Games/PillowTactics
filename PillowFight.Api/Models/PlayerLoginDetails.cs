using System.ComponentModel.DataAnnotations;

namespace PillowFight.Api.Models
{
    public class PlayerLoginDetails
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
