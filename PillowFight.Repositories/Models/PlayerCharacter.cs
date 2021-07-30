using PillowFight.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.Repositories.Models
{
    public class PlayerCharacter : Character, IPlayerCharacter
    {
        public int PlayerId { get; set; }

        public IPlayer Player { get; set; }

        public int Losses { get; set; }

        public int Wins { get; set; }
    }
}
