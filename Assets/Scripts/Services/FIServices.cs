using System.Collections.Generic;
using System.IO;
using FishingIdle.Managers.Interfaces;
using Newtonsoft.Json;

namespace FishingIdle.Services
{
    public static class FIServices
    {
        static List<FishingZoneDataOutput> FishingZoneDataOutputList = new();
        static List<InventoryItem> UserInventoryDataOutput = new();
        static List<ItemDataOutput> ItemsDataOutput = new();
        static CurrencyDataOutput CurrencyDataOutput = new();

        #region JSON Paths

        const string FISHING_ZONE_DATA_PATH = "Assets\\Resources\\JSON\\Datas\\FishingZonesData.json";
        const string CURRENCY_DATA_PATH = "Assets\\Resources\\JSON\\Datas\\CurrencyData.json";
        const string USER_INVENTORY_DATA_PATH = "Assets\\Resources\\JSON\\Datas\\UserInventoryData.json";
        const string ITEMS_DATA_PATH = "Assets\\Resources\\JSON\\Datas\\ItemsData.json";

        #endregion

        #region FishingZone Services

        public static void RetrieveFishingZoneData()
        {
            var json = File.ReadAllText(FISHING_ZONE_DATA_PATH);
            FishingZoneDataOutputList = JsonConvert.DeserializeObject<List<FishingZoneDataOutput>>(json);
        }
        
        public static List<FishingZoneDataOutput> GetFishingZoneDataOutputList()
        {
            return FishingZoneDataOutputList;
        }


        #endregion

        #region Currency Services

        public static void RetrieveCurrencyData()
        {
            var json = File.ReadAllText(CURRENCY_DATA_PATH);
            CurrencyDataOutput = JsonConvert.DeserializeObject<CurrencyDataOutput>(json);
        }
        
        public static CurrencyDataOutput GetCurrencyDataOutput()
        {
            return CurrencyDataOutput;
        }
        
        public static void SaveCurrencyData(CurrencyDataOutput currencyDataOutput)
        {
            var json = JsonConvert.SerializeObject(currencyDataOutput, Formatting.Indented);
            File.WriteAllText(CURRENCY_DATA_PATH, json);
        }

        #endregion

        #region UserInventory Services

        public static void RetrieveUserInventoryData()
        {
            var json = File.ReadAllText(USER_INVENTORY_DATA_PATH);
            UserInventoryDataOutput = JsonConvert.DeserializeObject<List<InventoryItem>>(json);
        }
        
        public static List<InventoryItem> GetUserInventoryDataOutput()
        {
            return UserInventoryDataOutput;
        }

        public static void SaveUserInventory(List<InventoryItem> inventoryItems)
        {
            var json = JsonConvert.SerializeObject(inventoryItems, Formatting.Indented);
            File.WriteAllText(USER_INVENTORY_DATA_PATH, json);
        }

        #endregion

        #region Items Services

        public static void RetrieveItemsData()
        {
            var json = File.ReadAllText(ITEMS_DATA_PATH);
            ItemsDataOutput = JsonConvert.DeserializeObject<List<ItemDataOutput>>(json);
        }
        
        public static List<ItemDataOutput> GetItemsDataOutput()
        {
            return ItemsDataOutput;
        }

        #endregion
    }
}