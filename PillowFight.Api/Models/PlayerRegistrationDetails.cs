using System.ComponentModel.DataAnnotations;

namespace PillowFight.Api.Models
{
    public class PlayerRegistrationDetails
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
