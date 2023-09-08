using System;
using FishingIdle.Managers.Interfaces;
using Newtonsoft.Json;

namespace FishingIdle
{
    public enum ItemRarity
    {
        [JsonProperty("COMMON")]
        COMMON,
        [JsonProperty("UNCOMMON")]
        UNCOMMON,
        [JsonProperty("RARE")]
        RARE,
        [JsonProperty("EPIC")]
        EPIC,
        [JsonProperty("LEGENDARY")]
        LEGENDARY,
        [JsonProperty("MYTHIC")]
        MYTHIC,
        [JsonProperty("GODLY")]
        GODLY,
        [JsonProperty("SPECIAL")]
        SPECIAL,
    }
    
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
        [JsonProperty("RESOURCE")]
        RESOURCE,
    }
    
    [Serializable]
    public record FishingZoneDataOutput
    {
        [JsonProperty("Id")] 
        public string ID;

        [JsonProperty("Name")] 
        public string ZoneName;

        [JsonProperty("Level")] 
        public int ZoneLevel;

        [JsonProperty("Unlocked")] 
        public bool IsUnlocked;

        [JsonProperty("FishingDuration")] 
        public float FishingDuration;

        [JsonProperty("MinFishRarity")]
        public ItemRarity MinFishRarity;
        
        [JsonProperty("MaxFishRarity")]
        public ItemRarity MaxFishRarity;
    }

    
    [Serializable]
    public record CurrencyDataOutput
    {
        [JsonProperty("SoftCurrency")] 
        public long SoftCurrency;

        [JsonProperty("HardCurrency")] 
        public long HardCurrency;
    }

    [Serializable]
    public record ItemDataOutput
    {
        [JsonProperty("ID")]
        public string ID;
        
        [JsonProperty("ItemName")]
        public string ItemName;
        
        [JsonProperty("Description")]
        public string Description;
        
        [JsonProperty("ItemType")]
        public InventoryItemType ItemType;
        
        [JsonProperty("CurrencyType")]
        public CurrencyType CurrencyType;
        
        [JsonProperty("IsSellable")]
        public bool IsSellable;
        
        [JsonProperty("IsCookable")]
        public bool IsCookable;
        
        [JsonProperty("IsCooked")]
        public bool IsCooked;
        
        [JsonProperty("IsEquipable")]
        public bool IsEquipable;
        
        [JsonProperty("IsStackable")]
        public bool IsStackable;
        
        
        
        [JsonProperty("Rarity")]
        public ItemRarity Rarity;
        
        [JsonProperty("Price")]
        public long Price;
        
        [JsonProperty("Hunger")]
        public float Hunger;
        
        [JsonProperty("Energy")]
        public float Energy;
    }
}