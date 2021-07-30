using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;

namespace PillowFight.Repositories.Models
{
    public class Weapon : Item, IWeapon
    {
        public int Attack { get; set; }

        public int Range { get; set; }
    }
}
