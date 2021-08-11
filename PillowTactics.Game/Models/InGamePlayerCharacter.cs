using PillowFight.Repositories.Models;

namespace PillowTactics.Game.Models
{
    public class InGamePlayerCharacter
    {
        public InGamePlayerCharacter(PlayerCharacter playerCharacter)
        {
            Id = playerCharacter.Id;
            Name = playerCharacter.Name;
            CharacterClass = playerCharacter.Class.ToString();
            Strength = playerCharacter.Strength;
            Dexterity = playerCharacter.Dexterity;
            Constitution = playerCharacter.Constitution;
            Intelligence = playerCharacter.Intelligence;
            Wisdom = playerCharacter.Wisdom;
            MainHandSlotItem = playerCharacter.MainHandSlotItem;
            TorsoSlotItem = playerCharacter.TorsoSlotItem;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string CharacterClass { get; set; }

        public int HP { get; set; }

        public int SpellPoints { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        public ArmorItem TorsoSlotItem { get; set; }

        public WeaponItem MainHandSlotItem { get; set; }

        public int XCoordinate { get; set; }

        public int YCoordinate { get; set; }
    }
}
