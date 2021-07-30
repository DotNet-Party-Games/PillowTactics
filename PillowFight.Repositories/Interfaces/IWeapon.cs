using PillowFight.Repositories.Enumerations;

namespace PillowFight.Repositories.Interfaces
{
    public interface IWeapon : IItem
    {
        public int Attack { get; set; }

        public int Range { get; set; }
    }
}
