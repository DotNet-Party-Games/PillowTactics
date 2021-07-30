using PillowFight.Repositories.Enumerations;

namespace PillowFight.Repositories.Interfaces
{
    public interface IWeaponItem : IItem
    {
        public int Attack { get; set; }

        public int Range { get; set; }
    }
}
