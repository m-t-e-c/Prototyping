using System;
using System.Collections.Generic;
using FishingIdle.Managers.Interfaces;

namespace FishingIdle.Models
{
    public class MarketModel
    {
        public event EventHandler<List<InventoryItem>> OnItemListChanged;

        readonly IInventoryManager _inventoryManager;

        List<InventoryItem> _itemList = new ();
        
        public MarketModel()
        {
            _inventoryManager = Locator.Instance.Resolve<IInventoryManager>();
        }

        public void GetConfig()
        {
            _itemList = _inventoryManager.GetAllItems();
            OnItemListChanged?.Invoke(this, _itemList);
        }
    }
}