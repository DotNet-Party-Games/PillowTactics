using PillowFight.Repositories.Interfaces;
using System.Collections.Generic;

namespace PillowTactics.Game.Models
{
    public class Team
    {
        public IEnumerable<IPlayerCharacter> Characters { get; set; }
    }
}
