using PillowFight.Repositories.Enumerations;

namespace PillowFight.Api.Models
{
    public class PlayerCharacter
    {
        public PlayerCharacter()
        {

        }

        public PlayerCharacter(Repositories.Models.PlayerCharacter playerCharacter)
        {
            Id = playerCharacter.Id;
            Name = playerCharacter.Name;
            Class = playerCharacter.Class;
            Strength = playerCharacter.Strength;
            Dexterity = playerCharacter.Dexterity;
            Constitution = playerCharacter.Constitution;
            Intelligence = playerCharacter.Intelligence;
            Wisdom = playerCharacter.Wisdom;
            MainHandSlotItem = new Weapon()
            {
                Name = playerCharacter.MainHandSlotItem.Name,
                Attack = playerCharacter.MainHandSlotItem.Attack,
                Range = playerCharacter.MainHandSlotItem.Range

            };
            TorsoSlotItem = new Armor()
            {
                Name = playerCharacter.TorsoSlotItem.Name,
                Defense = playerCharacter.TorsoSlotItem.Defense
            };
        }

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

        public int xCoordinate { get; set; }

        public int yCoordinate { get; set; }

        /*        public static explicit operator PlayerCharacter(Repositories.Models.PlayerCharacter playerCharacter)
                {
                    return new PlayerCharacter()
                    {
                        Id = playerCharacter.Id,
                        Name = playerCharacter.Name,
                        Class = playerCharacter.Class,
                        Strength = playerCharacter.Strength,
                        Dexterity = playerCharacter.Dexterity,
                        Constitution = playerCharacter.Constitution,
                        Intelligence = playerCharacter.Intelligence,
                        Wisdom = playerCharacter.Wisdom,
                        MainHandSlotItem = new Weapon()
                        {
                            Name = playerCharacter.MainHandSlotItem.Name,
                            Attack = playerCharacter.MainHandSlotItem.Attack,
                            Range = playerCharacter.MainHandSlotItem.Range

                        },
                        TorsoSlotItem = new Armor()
                        {
                            Name = playerCharacter.TorsoSlotItem.Name,
                            Defense = playerCharacter.TorsoSlotItem.Defense
                        }
                    };
                }*/
    }
}
