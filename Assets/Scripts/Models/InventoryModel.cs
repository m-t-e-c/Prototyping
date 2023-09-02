using System.Collections.Generic;
using FishingIdle.Managers.Interfaces;
using UnityEngine;

namespace FishingIdle.Models
{
    public class InventoryModel
    {
        IInventoryManager _inventoryManager;
        IMarketManager _marketManager;

        public readonly List<InventoryItem> itemList = new();
        
        public InventoryModel()
        {
            _inventoryManager = Locator.Instance.Resolve<IInventoryManager>();
            _marketManager = Locator.Instance.Resolve<IMarketManager>();

            itemList = _inventoryManager.GetAllItems();
        }
    }
}