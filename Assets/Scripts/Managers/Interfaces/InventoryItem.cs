using Newtonsoft.Json;

namespace FishingIdle.Managers.Interfaces
{

    public record InventoryItem
    {
        public ItemDataOutput ItemData { get; set; }
        public int ItemAmount { get; set; }
    }
}