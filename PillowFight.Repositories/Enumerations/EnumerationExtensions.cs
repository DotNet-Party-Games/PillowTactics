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
/*
        public static bool CanSlot(this CharacterClassEnum itemType)
        {

        }
*/
    }
}
