namespace PillowFight.Repositories.Interfaces
{
    public interface ITile : IAtom
    {
        public int MapId { get; set; }

        public int XPosition { get; set; }

        public int YPosition { get; set; }
    }
}
