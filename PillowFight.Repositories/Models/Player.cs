using PillowFight.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.Repositories.Models
{
    public class Player : IPlayer
    {
        public int Losses { get; set; }

        public int Wins { get; set; }

        [Key]
        public string Name { get; set; }

        public string Password { get; set; } // Only fully encrypted Passwords here!
    }
}
