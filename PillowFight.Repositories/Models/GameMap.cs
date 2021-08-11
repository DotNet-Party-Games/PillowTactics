using PillowFight.Repositories.Interfaces;
using System.Collections.Generic;

namespace PillowFight.Repositories.Models
{
    public class GameMap
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Width { get; set; }

        public int Depth { get; set; }

        public List<ITile> Tiles { get; set; }
    }
}
