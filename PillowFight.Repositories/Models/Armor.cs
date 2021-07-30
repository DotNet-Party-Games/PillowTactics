using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;

namespace PillowFight.Repositories.Models
{
    class Armor : Item, IArmor
    {
        public int Defense { get; set; }
    }
}
