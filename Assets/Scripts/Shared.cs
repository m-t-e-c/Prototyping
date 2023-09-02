using System;
using System.Collections.Generic;
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

        [JsonProperty("Weight")] 
        public float Weight;

        [JsonProperty("Price")] 
        public float Price;

        [JsonProperty("Rarity")] 
        public int Rarity;
    }
}