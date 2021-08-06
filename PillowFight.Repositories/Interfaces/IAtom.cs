using PillowFight.Repositories.Enumerations;
using System.Collections.Generic;

namespace PillowFight.Repositories.Interfaces
{
    /// <summary>
    /// The base interface for everything within the game world.
    /// </summary>
    public interface IAtom
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public List<StatusEffectEnum> StatusEffects { get; set; }
    }
}
