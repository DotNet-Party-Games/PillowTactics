using PillowFight.Repositories.Enumerations;

namespace PillowFight.Api.Models
{
    public class CharacterCreationDetails
    {
        public string Name { get; set; }

        public CharacterClassEnum Class { get; set; }
    }
}
