using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace FishingIdle.Services
{
    public static class Services
    {
        static List<FishingZoneDataOutput> FishingZoneDataOutputList = new List<FishingZoneDataOutput>();

        const string FISHING_ZONE_DATA_PATH = "Assets\\Resources\\JSON\\Datas\\FishingZones.json";

        public static void RetrieveData()
        {
            var json = File.ReadAllText(FISHING_ZONE_DATA_PATH);
            FishingZoneDataOutputList = JsonConvert.DeserializeObject<List<FishingZoneDataOutput>>(json);
        }
        
        public static List<FishingZoneDataOutput> GetFishingZoneDataOutputList()
        {
            return FishingZoneDataOutputList;
        }
    }
}