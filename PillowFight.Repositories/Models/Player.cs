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
        [Key]
        public int PlayerId { get; set; }

        public int Losses { get; set; }

        public int Wins { get; set; }

        public string Name { get; set;}
    }
}
