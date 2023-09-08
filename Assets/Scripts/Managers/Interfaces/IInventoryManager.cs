using System;
using System.Collections.Generic;

namespace FishingIdle.Managers.Interfaces
{
    public interface IInventoryManager
    {
        public event EventHandler<InventoryItem> OnItemAdded;
        public event EventHandler<InventoryItem> OnItemRemoved; 
        
        public List<InventoryItem> GetAllItems();
        public List<InventoryItem> GetItemsByType(InventoryItemType type);
        public InventoryItem GetItem(string itemID);
        public void AddItem(ItemDataOutput item, int amount = 1);
        public void RemoveItem(string itemID);
    }
}