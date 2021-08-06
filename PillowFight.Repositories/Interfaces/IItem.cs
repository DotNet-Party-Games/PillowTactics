using PillowFight.Repositories.Enumerations;

namespace PillowFight.Repositories.Interfaces
{
    public interface IItem : IAtom
    {
        public ItemTypeEnum Type { get; set; }

        public ItemSlotEnum Slot => Type.GetSlotLocation();
    }
}
