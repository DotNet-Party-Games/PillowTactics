using PillowFight.Repositories.Models;

namespace PillowFight.Repositories.Enumerations
{
    public static class EnumerationExtensions
    {
        public static ItemSlotEnum GetSlotLocation(this ItemTypeEnum itemType)
        {
            switch (itemType)
            {
                //weapons
                case (ItemTypeEnum.LongSword):
                    return ItemSlotEnum.EitherHand;
                //armor
                case (ItemTypeEnum.Boots):
                    return ItemSlotEnum.Legs;
                case (ItemTypeEnum.Gloves):
                    return ItemSlotEnum.Arms;
                case (ItemTypeEnum.Helmet):
                    return ItemSlotEnum.Head;
                case (ItemTypeEnum.Leather):
                    return ItemSlotEnum.Torso;
                case (ItemTypeEnum.PlateMail):
                    return ItemSlotEnum.Torso;
                case (ItemTypeEnum.Robe):
                    return ItemSlotEnum.Torso;
                default:
                    return ItemSlotEnum.Unslotted;
            }
        }

        public static void SetStartingStats(this CharacterClassEnum characterClass, Character character)
        {
            switch (characterClass)
            {
                case (CharacterClassEnum.Fighter):
                    character.Strength = 3;
                    character.Dexterity = 2;
                    character.Constitution = 3;
                    character.Intelligence = 1;
                    character.Wisdom = 1;
                    break;
                case (CharacterClassEnum.Rogue):
                    character.Strength = 2;
                    character.Dexterity = 3;
                    character.Constitution = 2;
                    character.Intelligence = 2;
                    character.Wisdom = 2;
                    break;
                case (CharacterClassEnum.Wizard):
                    character.Strength = 1;
                    character.Dexterity = 1;
                    character.Constitution = 1;
                    character.Intelligence = 3;
                    character.Wisdom = 2;
                    break;
                default:
                    character.Strength = 2;
                    character.Dexterity = 2;
                    character.Constitution = 2;
                    character.Intelligence = 2;
                    character.Wisdom = 2;
                    break;
            }
        }

        //Started to add this and then realized Julian wanted equipment compatibility to be based on stats, for some reason
        /*        public static bool CanSlot(this CharacterClassEnum itemType)
                {
                    return ;
                }*/
    }
}
