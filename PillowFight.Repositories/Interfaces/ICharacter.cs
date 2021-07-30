using PillowFight.Repositories.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PillowFight.Repositories.Interfaces
{
    public interface ICharacter: IAtom
    {
        public CharacterClassEnum Class { get; set; }

        //Should these be derived from class, constitution, intelligence values?
/*        public int HP { get; set; }

        public int SpellPoints { get; set; }*/

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

        public int TorsoSlotItemId { get; set; }

        public IArmorItem TorsoSlotItem { get; set; }
    }
}
