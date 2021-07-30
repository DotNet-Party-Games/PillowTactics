using PillowFight.Repositories.Interfaces;

namespace PillowFight.Repositories.Models
{
    public class SpellItem : WeaponItem, ISpellItem
    {
        public int Cost { get; set; }
    }
}
