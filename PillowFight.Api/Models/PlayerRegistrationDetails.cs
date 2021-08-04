using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PillowFight.Api.Models
{
    public class PlayerRegistrationDetails
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string ContactName { get; set; }

        [Required]
        public string Email { get; set; }
    }
}
