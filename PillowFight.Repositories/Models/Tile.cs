using PillowFight.Repositories.Interfaces;

namespace PillowFight.Repositories.Models
{
    public class Tile : IAtom
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int MapId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }
    }
}
