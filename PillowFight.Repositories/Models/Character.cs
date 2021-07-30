using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.Repositories.Models
{
    public class Character : ICharacter
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<StatusEffectEnum> StatusEffects { get; set; }

        public CharacterClassEnum Class { get; set; }

        public int Strength { get; set; }

        public int Dexterity { get; set; }

        public int Constitution { get; set; }

        public int Intelligence { get; set; }

        public int Wisdom { get; set; }

        public int ArmsSlotItemId { get; set; }

        public IArmorItem ArmsSlotItem { get; set; }

        public int HeadSlotItemId { get; set; }

        public IArmorItem HeadSlotItem { get; set; }

        public int LegsSlotItemId { get; set; }

        public IArmorItem LegsSlotItem { get; set; }

        public int MainHandSlotItemId { get; set; }

        public IWeaponItem MainHandSlotItem { get; set; }

        public int OffHandSlotSlotItemId { get; set; }

        public IWeaponItem OffHandSlotItem { get; set; }

        public int TosoSlotItemId { get; set; }

        public IArmorItem TorsoSlotItem { get; set; }
    }
}
