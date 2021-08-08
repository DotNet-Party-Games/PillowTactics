using System.Collections.Generic;

namespace PillowFight.Repositories.Interfaces
{
    public interface IMap : IAtom
    {
        public int Width { get; set; }

        public int Depth { get; set; }

        public List<ITile> Tiles { get; set; }
    }
}
