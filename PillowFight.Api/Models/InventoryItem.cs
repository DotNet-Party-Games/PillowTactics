namespace PillowFight.Api.Models
{
    public class InventoryItem
    {
        public InventoryItem()
        {

        }

        public InventoryItem(PillowFight.Repositories.Models.InventoryItem inventoryItem)
        {
            Id = inventoryItem.Id;
            ItemId = inventoryItem.ItemId;
            ItemName = inventoryItem.Item.Name;
            Quantity = inventoryItem.Quantity;
        }

        public int Id { get; set; }

        public int ItemId { get; set; }

        public string ItemName { get; set; }

        public int Quantity { get; set; }
    }
}
