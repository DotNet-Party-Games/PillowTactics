using PillowFight.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.Repositories.Models
{
    public class PlayerCharacter : Character, IPlayerCharacter
    {
        [ForeignKey("Player")]
        public int PlayerId { get; set; }
        public string Player { get; set; }
    }
}
