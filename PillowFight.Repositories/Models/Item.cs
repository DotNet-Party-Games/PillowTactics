using PillowFight.Repositories.Enumerations;
using PillowFight.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace PillowFight.Repositories.Models
{
    public class Item : IItem   
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<StatusEffectEnum> StatusEffects { get; set; }

        public ItemTypeEnum Type { get; set; }
    }
}
