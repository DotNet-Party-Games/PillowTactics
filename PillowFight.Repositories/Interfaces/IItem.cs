using PillowFight.Repositories.Enumerations;
using System.Collections.Generic;

namespace PillowFight.Repositories.Interfaces
{
    public interface IItem
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public ItemTypeEnum Type { get; set; }

        public ItemSlotEnum Slot => Type.GetSlotLocation();

        public ICollection<StatusEffectEnum> StatusEffects { get; set; }
    }
}
