using PillowFight.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace PillowFight.Repositories.Models
{
    public class PlayerCharacter : Character, IPlayerCharacter
    {
        Player _player;

        [ForeignKey("Player")]
        public int PlayerId { get; set; }

        public IPlayer Player
        {
            get
            {
                return _player;
            }
            set
            {
                _player = (Player)value;
            }
        }
    }
}
