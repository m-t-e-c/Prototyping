using System;
using System.Collections.Generic;
using FishingIdle.Managers.Interfaces;
using FishingIdle.Services;

namespace FishingIdle.Managers
{
    public class InventoryManager : IInventoryManager
    {
        public event EventHandler<InventoryItem> OnItemAdded;
        public event EventHandler<InventoryItem> OnItemRemoved;

        List<InventoryItem> _userItems = new();

        public InventoryManager()
        {
            GetConfig();
        }

        void GetConfig()
        {
            _userItems = FIServices.GetUserInventoryDataOutput();
        }
        
        public List<InventoryItem> GetAllItems()
        {
            return _userItems;
        }

        public List<InventoryItem> GetItemsByType(InventoryItemType type)
        {
            return _userItems.FindAll(item => item.ItemData.ItemType == type);
        }

        public InventoryItem GetItem(string itemID)
        {
            return _userItems.Find(item => item.ItemData.ID.Equals(itemID));
        }

        public void AddItem(ItemDataOutput itemData, int amount = 1)
        {
            bool isItemExist = _userItems.Exists(item => item.ItemData.ID.Equals(itemData.ID));

            if (isItemExist)
            {
                var userItem = GetItem(itemData.ID);
                userItem.ItemAmount += amount;
                OnItemAdded?.Invoke(this, userItem);
            }
            else
            {
                var newItem = new InventoryItem()
                {
                    ItemData = itemData,
                    ItemAmount = amount,
                };
                _userItems.Add(newItem);
                OnItemAdded?.Invoke(this, newItem);
            }
            
            FIServices.SaveUserInventory(_userItems);
        }

        public void RemoveItem(string itemID)
        {
            bool isItemExist = _userItems.Exists(item => item.ItemData.ID.Equals(itemID));

            if (isItemExist)
            {
                var userItem = GetItem(itemID);
                if (userItem.ItemAmount > 1)
                {
                    userItem.ItemAmount -= 1;
                }
                else
                {
                    _userItems.Remove(userItem);
                }
                
                OnItemRemoved?.Invoke(this, userItem);
                FIServices.SaveUserInventory(_userItems);
            }
        }
    }
}