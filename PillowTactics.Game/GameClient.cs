using PillowFight.Repositories.Models;
using System.Collections.Generic;

namespace PillowTactics.Game
{
    public class GameClient
    {
        private readonly int _userId1;
        private readonly IEnumerable<int> _characterIds1;
        private readonly int _userId2;
        private readonly IEnumerable<int> _characterIds2;

        public GameClient(int userId1, IEnumerable<int> characterIds1, int userId2, IEnumerable<int> characterIds2)
        {
            this._userId1 = userId1;
            this._characterIds1 = characterIds1;
            this._userId2 = userId2;
            this._characterIds2 = characterIds2;
        }

        public Map Map { get; set; }

        public Team TeamA { get; set; }

        public Team TeamB { get; set; }
    }
}
