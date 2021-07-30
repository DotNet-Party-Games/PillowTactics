using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;
using System.Collections.Generic;

namespace PillowFight.Repositories.Models
{
    public class Item : IItem   
    {
        public int Id { get; set; }

        public ItemTypeEnum Type { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public EquipmentSlotEnum Slot => Type.GetSlotLocation();

        public ICollection<StatusEffectEnum> StatusEffects { get; set; }
    }
}
