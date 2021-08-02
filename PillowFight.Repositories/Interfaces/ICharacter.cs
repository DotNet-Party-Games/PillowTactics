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

        public string ArmsSlotItem { get; set; }

        public int HeadSlotItemId { get; set; }

        public string HeadSlotItem { get; set; }

        public int LegsSlotItemId { get; set; }

        public string LegsSlotItem { get; set; }

        public int MainHandSlotItemId { get; set; }

        public string MainHandSlotItem { get; set; }

        public int OffHandSlotSlotItemId { get; set; }

        public string OffHandSlotItem { get; set; }

        public int TorsoSlotItemId { get; set; }

        public string TorsoSlotItem { get; set; }
    }
}
