using PillowFight.Repositories.Interfaces;
using System.Collections.Generic;

namespace PillowFight.Repositories.Models
{
    public class GameMap
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Rows { get; set; }

        public int Columns { get; set; }

        public List<ITile> Tiles { get; set; }
    }
}
