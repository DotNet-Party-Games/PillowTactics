using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace PillowFight.Repositories.Models
{
    public class ArmorItem : Item, IArmorItem
    {
        [Key]
        public int Id { get; set; }
        public int Defense { get; set; }
    }
}
