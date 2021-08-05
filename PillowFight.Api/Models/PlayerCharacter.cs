using PillowFight.Repositories.Enumerations;

namespace PillowFight.Api.Models
{
    public class PlayerCharacter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public CharacterClassEnum Class { get; set; }

        //Should these be derived from class, constitution, intelligence values?
        /*        public int HP { get; set; }

                public int SpellPoints { get; set; }*/

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        public Armor TorsoSlotItem { get; set; }

        public Weapon MainHandSlotItem { get; set; }
    }
}
