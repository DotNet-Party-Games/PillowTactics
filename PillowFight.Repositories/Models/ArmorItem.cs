using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;

namespace PillowFight.Repositories.Models
{
    class ArmorItem : Item, IArmorItem
    {
        public int Defense { get; set; }
    }
}
