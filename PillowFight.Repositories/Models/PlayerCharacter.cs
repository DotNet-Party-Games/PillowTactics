using System.ComponentModel.DataAnnotations.Schema;

namespace PillowFight.Repositories.Models
{
    public class PlayerCharacter : Character
    {
        [ForeignKey("Player")]
        public int PlayerId { get; set; }
    }
}
