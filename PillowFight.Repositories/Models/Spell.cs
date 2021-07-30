using PillowFight.Repositories.Interfaces;

namespace PillowFight.Repositories.Models
{
    public class Spell : Weapon, ISpell
    {
        public int Cost { get; set; }
    }
}
