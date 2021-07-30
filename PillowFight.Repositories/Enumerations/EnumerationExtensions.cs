using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.Repositories.Enumerations
{
    public static class EnumerationExtensions
    {
        public static ItemSlotEnum GetSlotLocation(this ItemTypeEnum itemType)
        {
            switch (itemType)
            {
                //weapons
                case (ItemTypeEnum.Sword):
                    return ItemSlotEnum.Torso;
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

        //Started to add this and then realized Julian wanted equipment compatibility to be based on stats, for some reason
/*        public static bool CanSlot(this CharacterClassEnum itemType)
        {
            return ;
        }*/
    }
}
