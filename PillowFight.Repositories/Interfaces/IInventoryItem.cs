namespace PillowFight.Repositories.Interfaces
{
    public interface IInventoryItem
    {
        public int PlayerId { get; set; }

        public IPlayer Player { get; set; }

        public int ItemId { get; set; }

        public IItem Item { get; set; }

        public int Quantity { get; set; }
    }
}
