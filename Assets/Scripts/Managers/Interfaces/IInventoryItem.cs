namespace FishingIdle.Managers.Interfaces
{
    public enum InventoryItemType
    {
        FISH,
        BAIT,
        FOOD,
        TOOL,
    }
    
    public record InventoryItem
    {
        public string ID { get; set; }
        public string ItemName { get; set; }
        public InventoryItemType ItemType { get; set; }
        public int ItemCount { get; set; }
    }
}