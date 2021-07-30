using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.Repositories.Enumerations
{
    public static class EnumerationExtensions
    {
        public static EquipmentSlotEnum GetSlotLocation(this ItemTypeEnum itemType)
        {
            switch (itemType)
            {
                //weapons
                case (ItemTypeEnum.Sword):
                    return EquipmentSlotEnum.Torso;
                //armor
                case (ItemTypeEnum.Boots):
                    return EquipmentSlotEnum.Legs;
                case (ItemTypeEnum.Gloves):
                    return EquipmentSlotEnum.Arms;
                case (ItemTypeEnum.Helmet):
                    return EquipmentSlotEnum.Head;
                case (ItemTypeEnum.Leather):
                    return EquipmentSlotEnum.Torso;
                case (ItemTypeEnum.PlateMail):
                    return EquipmentSlotEnum.Torso;
                case (ItemTypeEnum.Robe):
                    return EquipmentSlotEnum.Torso;
                default:
                    return EquipmentSlotEnum.Unslotted;
            }
        }
    }
}
