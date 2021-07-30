using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;

namespace PillowFight.Repositories.Models
{
    public class WeaponItem : Item, IWeaponItem
    {
        public int Attack { get; set; }

        public int Range { get; set; }
    }
}
