using Newtonsoft.Json;

namespace FishingIdle.Managers.Interfaces
{
    public enum InventoryItemType
    {
        [JsonProperty("FISH")]
        FISH,
        [JsonProperty("BAIT")]
        BAIT,
        [JsonProperty("FOOD")]
        FOOD,
        [JsonProperty("TOOL")]
        TOOL,
    }

    public record InventoryItem
    {
        public string ID { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public int ItemAmount { get; set; }
        public bool IsSellable { get; set; }
        public long ItemPrice { get; set; }
        public InventoryItemType ItemType { get; set; }
        public CurrencyType CurrencyType { get; set; }
    }
}