namespace PillowFight.Api.Models
{
    public class CharacterAction
    {
        public int CharacterId { get; set; }

        public string ActionType { get; set; }

        public MapPosition Location { get; set; }
    }
}
