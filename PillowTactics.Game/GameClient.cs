using PillowFight.Repositories.Models;
using PillowTactics.Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PillowTactics.Game
{
    public class GameClient
    {
        private readonly IEnumerable<InGamePlayerCharacter> _allCharacters;
        private Queue<InGamePlayerCharacter> _turnSortedCharacters = new();

        public GameClient(Player player1, IEnumerable<PlayerCharacter> team1, Player player2, IEnumerable<PlayerCharacter> team2, GameMap gameMap = null)
        {
            Player1 = player1;
            Team1 = team1.Select(a_playerCharacter => new InGamePlayerCharacter(a_playerCharacter));
            Player2 = player2;
            Team2 = team1.Select(a_playerCharacter => new InGamePlayerCharacter(a_playerCharacter));
            GameMap = gameMap;

            if (gameMap == null)
            {
                GameMap = new()
                {
                    Name = "Demo Map",
                    Description = string.Empty,
                    Width = 12,
                    Depth = 12
                };
            }

            _allCharacters = Team1.Concat(Team2);

            /*
             * Set character starting positions.
            */
            var startColumn = (GameMap.Width - Team2.Count()) / 2;
            foreach (var character in Team1)
            {
                character.XCoordinate = startColumn++;
                character.YCoordinate = 0;
            }
            startColumn = (GameMap.Width - Team2.Count()) / 2;
            foreach (var character in Team2)
            {
                character.XCoordinate = startColumn++;
                character.YCoordinate = GameMap.Depth;
            }
        }

        public Player Player1 { get; }
        public IEnumerable<InGamePlayerCharacter> Team1 { get; }
        public Player Player2 { get; }
        public IEnumerable<InGamePlayerCharacter> Team2 { get; }
        public GameMap GameMap { get; }

        public int GetActiveCharacter()
        {
            // All character's have taken their turns? Get the new turn order.
            if (_turnSortedCharacters.Any())
            {
                // Poor man's tiebreaking.
                _turnSortedCharacters = new Queue<InGamePlayerCharacter>(_allCharacters
                    .Select(a_character => new { a_character, TieBreaker = Guid.NewGuid() })
                    .OrderByDescending(a_tieBreakingCharacter => new { a_tieBreakingCharacter.a_character.Dexterity, a_tieBreakingCharacter.TieBreaker })
                    .Select(a_tieBreakingCharacter => a_tieBreakingCharacter.a_character));
            }

            InGamePlayerCharacter activeCharacter;
            while ((activeCharacter = _turnSortedCharacters.Dequeue()).HP < 1);
            return activeCharacter.Id;
        }
    }
}
