using PillowFight.Repositories.Interfaces;

namespace PillowFight.Repositories.Models
{
    public class ArmorItem : Item, IArmorItem
    {
        public int Defense { get; set; }
    }
}
