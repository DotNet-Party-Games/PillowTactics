using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Models;
using PillowTactics.Game.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PillowTactics.Game
{
    /// <summary>
    /// I'm taking some shortcuts with this one.
    /// Call GetActiveCharacterState to get the active character's available actions (Attack, Move, etc.).
    ///   If null, access Winner to get the winning player. Else:
    /// Call GetActionOptions to get the action's options (for now, the tile's that can be targeted).
    /// Call ExecuteAction to complete an action on the target.
    /// Repeat until there's a winner.
    /// </summary>
    public class GameClient
    {
        #region Fields
        private readonly Random _randomizer = new();
        private readonly IEnumerable<InGamePlayerCharacter> _allCharacters;
        private Queue<InGamePlayerCharacter> _turnSortedCharacters = new();
        private InGamePlayerCharacter _activeCharacter;
        private Player _winner;
        #endregion

        #region Constructors
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
                    Rows = 12,
                    Columns = 12
                };
            }

            _allCharacters = Team1.Concat(Team2);

            /*
             * Set character starting positions.
            */
            var startColumn = (GameMap.Columns - Team2.Count()) / 2;
            foreach (var character in Team1)
            {
                character.Position.Row = startColumn++;
                character.Position.Column = 0;
            }
            startColumn = (GameMap.Columns - Team2.Count()) / 2;
            foreach (var character in Team2)
            {
                character.Position.Row = startColumn++;
                character.Position.Column = GameMap.Columns;
            }

            _activeCharacter = GetNextActiveCharacter();
        }
        #endregion

        #region Properties
        public Player Player1 { get; }

        public Player Player2 { get; }

        public Player Winner => _winner;

        public IEnumerable<InGamePlayerCharacter> Team1 { get; }

        public IEnumerable<InGamePlayerCharacter> Team2 { get; }

        public GameMap GameMap { get; }
        #endregion

        #region Public Methods
        public IEnumerable<InGamePlayerCharacter> ExecuteAction(ActionTypeEnum actionType, MapPosition target)
        {
            _activeCharacter.AvailableActions.Remove(actionType);

            /*
             * Area-of-effect target calculations go here.
             */

            switch (actionType)
            {
                case ActionTypeEnum.EndTurn:
                    break;
                case ActionTypeEnum.Move:
                    _activeCharacter.Position = target;
                    break;
                case ActionTypeEnum.Attack:
                    var targetedCharacters = _allCharacters.Where(a_character => a_character.Position == target).ToList();
                    // Update damage calculation when mechanics are formalized.
                    targetedCharacters.ForEach(a_character => a_character.CurrentHp = a_character.CurrentHp > _activeCharacter.Strength ? a_character.CurrentHp - _activeCharacter.Strength : 0);
                    break;
                default:
                    break;
            }

            return _allCharacters;
        }

        public IEnumerable<MapPosition> GetActionOptions(ActionTypeEnum actionType)
        {
            List<MapPosition> area = null;

            switch (actionType)
            {
                case ActionTypeEnum.EndTurn:
                    break;
                case ActionTypeEnum.Move:
                    area = GetTargetableArea(_activeCharacter.Position, _activeCharacter.Dexterity).ToList();
                    area.Remove(_activeCharacter.Position);
                    break;
                case ActionTypeEnum.Attack:
                    area = GetTargetableArea(_activeCharacter.Position, _activeCharacter.MainHandSlotItem.Range).ToList();
                    area.Remove(_activeCharacter.Position);
                    break;
                default:
                    break;
            }

            return area;
        }

        public InGamePlayerCharacter GetActiveChararacter()
        {
            // Check for a winner.
            if (Team1.All(a_character => a_character.CurrentHp == 0))
            {
                _winner = Player2;
                return null;
            }
            if (Team2.All(a_character => a_character.CurrentHp == 0))
            {
                _winner = Player1;
                return null;
            }

            if (!_activeCharacter.AvailableActions.Any() ||
                _activeCharacter.AvailableActions.All(a_availableAction => a_availableAction == ActionTypeEnum.EndTurn))
            {
                _activeCharacter = GetNextActiveCharacter();
            }

            return _activeCharacter;
        }

        #endregion

        #region Private Methods
        private InGamePlayerCharacter GetNextActiveCharacter()
        {
            // All character's have taken their turns? Get the new turn order.
            if (!_turnSortedCharacters.Any())
            {
                // Poor man's tiebreaking.
                _turnSortedCharacters = new Queue<InGamePlayerCharacter>(_allCharacters
                    .Select(a_character => new { a_character, TieBreaker = _randomizer.Next() })
                    .OrderByDescending(a_tieBreakingCharacter => a_tieBreakingCharacter.a_character.Dexterity)
                    .ThenByDescending(a_tieBreakingCharacter => a_tieBreakingCharacter.TieBreaker)
                    .Select(a_tieBreakingCharacter => a_tieBreakingCharacter.a_character));
            }

            // Return the first player in the queue that's alive.
            InGamePlayerCharacter activeCharacter;
            while ((activeCharacter = _turnSortedCharacters.Dequeue()).CurrentHp < 1) ;
            activeCharacter.AvailableActions = activeCharacter.Actions;
            return activeCharacter;
        }

        /// <summary>
        /// Taking the biggest shortcut on this one.
        /// </summary>
        /// <param name="origin"></param>
        /// <param name="range"></param>
        /// <returns></returns>
        private IEnumerable<MapPosition> GetTargetableArea(MapPosition origin, int range)
        {
            List<MapPosition> targetableArea = new();

            var rowStart = range > origin.Row ? 0 : origin.Row - range;
            var rowEnd = origin.Row + range > GameMap.Rows ? GameMap.Rows : origin.Row + range;
            var columnStart = range > origin.Column ? 0 : origin.Column - range;
            var columnEnd = origin.Column + range > GameMap.Columns ? GameMap.Columns : origin.Column + range;
            for (int row = rowStart; row <= rowEnd ; row++)
            {
                for (int column = columnStart; column <= columnEnd; column++)
                {
                    targetableArea.Add(new MapPosition { Row = row, Column = column });
                }
            }

            return targetableArea;
        }
        #endregion
    }
}
