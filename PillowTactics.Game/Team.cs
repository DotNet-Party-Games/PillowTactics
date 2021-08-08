using PillowFight.Repositories.Interfaces;
using System.Collections.Generic;

namespace PillowTactics.Game
{
    public class Team
    {
        public IEnumerable<IPlayerCharacter> Characters { get; set; }
    }
}
