using System;
using System.Collections.Generic;
using FishingIdle.Managers.Interfaces;
using Newtonsoft.Json;

namespace FishingIdle
{
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

        [JsonProperty("FishList")] 
        public List<FishData> FishList;
    }

    [Serializable]
    public record FishData
    {
        [JsonProperty("Id")] 
        public string ID;
        
        [JsonProperty("Name")] 
        public string FishName;
        
        [JsonProperty("Description")]
        public string Description;

        [JsonProperty("Weight")] 
        public float Weight;

        [JsonProperty("Price")] 
        public long Price;
        
        [JsonProperty("CurrencyType")] 
        public CurrencyType CurrencyType;

        [JsonProperty("Rarity")] 
        public int Rarity;
    }
    
    [Serializable]
    public record CurrencyDataOutput
    {
        [JsonProperty("SoftCurrency")] 
        public long SoftCurrency;

        [JsonProperty("HardCurrency")] 
        public long HardCurrency;
    }
}