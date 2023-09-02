using System;
using System.Collections.Generic;

namespace FishingIdle.Managers.Interfaces
{
    
    public class InventoryItemParams : EventArgs
    {
        public string ID;
        public string Name;
        public int Amount;
        public InventoryItemType InventoryItemType;
    }
    
    
    public interface IInventoryManager
    {
        public event EventHandler<InventoryItem> OnItemAdded;
        public event EventHandler<InventoryItem> OnItemRemoved; 
        
        public List<InventoryItem> GetAllItems();
        public List<InventoryItem> GetItemsByType(InventoryItemType type);
        public InventoryItem GetItem(string itemID);
        public void AddItem(InventoryItemParams item);
        public void RemoveItem(InventoryItemParams item);
    }
}