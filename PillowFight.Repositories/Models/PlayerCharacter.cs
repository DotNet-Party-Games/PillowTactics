using PillowFight.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace PillowFight.Repositories.Models
{
    public class PlayerCharacter : Character, IPlayerCharacter
    {
        [ForeignKey("Player")]
        public int PlayerId { get; set; }
    }
}
