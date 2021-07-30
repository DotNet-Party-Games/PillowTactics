using PillowFight.Repositories.Enumerations;
using System.Collections.Generic;
using System.Linq;

namespace PillowFight.Repositories.Interfaces
{
    public interface IItem : IAtom
    {
        public ItemTypeEnum Type { get; set; }

        public ItemSlotEnum Slot => Type.GetSlotLocation();
    }
}
