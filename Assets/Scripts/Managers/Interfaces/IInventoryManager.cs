using System;
using System.Collections.Generic;

namespace FishingIdle.Managers.Interfaces
{
    
    public class InventoryItemParams : EventArgs
    {
        public string ID;
        public string Name;
        public string Description;
        public int Amount;
        public InventoryItemType InventoryItemType;
        public CurrencyType CurrencyType;
        public bool IsSellable;
        public long Price;
    }
    
    
    public interface IInventoryManager
    {
        public event EventHandler<InventoryItem> OnItemAdded;
        public event EventHandler<InventoryItem> OnItemRemoved; 
        
        public List<InventoryItem> GetAllItems();
        public List<InventoryItem> GetItemsByType(InventoryItemType type);
        public InventoryItem GetItem(string itemID);
        public void AddItem(InventoryItemParams item);
        public void RemoveItem(string itemID);
    }
}