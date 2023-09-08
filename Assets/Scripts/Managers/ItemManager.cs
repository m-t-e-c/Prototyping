using System.Collections.Generic;
using FishingIdle.Managers.Interfaces;
using FishingIdle.Services;
using UnityEngine;

namespace FishingIdle.Managers
{
    public class ItemManager : IItemManager
    {

        readonly List<ItemDataOutput> _items = new();
        
        public ItemManager()
        {
            _items = FIServices.GetItemsDataOutput();
        }

        public ItemDataOutput GetItem(string itemID)
        {
            return _items.Find(item => item.ID == itemID);
        }

        public ItemDataOutput GetCookedItem(ItemDataOutput itemData)
        {
            var cookedItem = _items.Find(item => item.ItemName == itemData.ItemName && item.IsCooked);
            if (cookedItem == null)
            {
                Debug.LogError($"Cooked item with ID {itemData.ItemName} not found");
                return null;
            }

            return cookedItem;
        }

        public List<ItemDataOutput> GetItems()
        {
            if (_items.Count == 0)
            {
                Debug.Log("Items list is empty!");
                return null;
            }
            return _items;
        }
    }
}