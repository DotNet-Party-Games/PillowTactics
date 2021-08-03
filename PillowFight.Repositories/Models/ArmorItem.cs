using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PillowFight.Repositories.Models
{
    public class ArmorItem : Item, IArmorItem
    {
        public int Defense { get; set; }
    }
}
