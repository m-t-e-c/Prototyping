using System;
using System.Collections.Generic;
using FishingIdle.Managers.Interfaces;

namespace FishingIdle.Managers
{
    public class InventoryManager : IInventoryManager
    {
        public event EventHandler<InventoryItem> OnItemAdded;
        public event EventHandler<InventoryItem> OnItemRemoved;

        readonly List<InventoryItem> _userItems = new();

        public List<InventoryItem> GetAllItems()
        {
            return _userItems;
        }

        public List<InventoryItem> GetItemsByType(InventoryItemType type)
        {
            return _userItems.FindAll(item => item.ItemType == type);
        }

        public InventoryItem GetItem(string itemID)
        {
            return _userItems.Find(item => item.ID.Equals(itemID));
        }

        public void AddItem(InventoryItemParams inventoryItemParams)
        {
            bool isItemExist = _userItems.Exists(item => item.ID.Equals(inventoryItemParams.ID));

            if (isItemExist)
            {
                var userItem = GetItem(inventoryItemParams.ID);
                userItem.ItemCount += inventoryItemParams.Amount;
                OnItemAdded?.Invoke(this, userItem);
            }
            else
            {
                var newItem = new InventoryItem()
                {
                    ID = inventoryItemParams.ID,
                    ItemName = inventoryItemParams.Name,
                    ItemType = inventoryItemParams.InventoryItemType,
                    ItemCount = inventoryItemParams.Amount
                };
                _userItems.Add(newItem);
                OnItemAdded?.Invoke(this, newItem);
            }
        }

        public void RemoveItem(InventoryItemParams inventoryItemParams)
        {
            bool isItemExist = _userItems.Exists(item => item.ID.Equals(inventoryItemParams.ID));

            if (isItemExist)
            {
                var userItem = GetItem(inventoryItemParams.ID);
                if (userItem.ItemCount > 1)
                {
                    userItem.ItemCount -= inventoryItemParams.Amount;
                }
                else
                {
                    _userItems.Remove(userItem);
                }
                
                OnItemRemoved?.Invoke(this, userItem);
            }
        }
    }
}