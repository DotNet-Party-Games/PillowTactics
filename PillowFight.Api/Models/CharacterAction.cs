using PillowFight.Repositories.Enumerations;

namespace PillowFight.Api.Models
{
    public class CharacterAction
    {
        public int CharacterId { get; set; }

        public ActionTypeEnum ActionType { get; set; }

        public MapCoordinate Location { get; set; }
    }
}
