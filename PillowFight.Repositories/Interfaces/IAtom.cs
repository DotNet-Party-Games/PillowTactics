using PillowFight.Repositories.Enumerations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public IQueryable<StatusEffectEnum> StatusEffects { get; set; }
    }
}
