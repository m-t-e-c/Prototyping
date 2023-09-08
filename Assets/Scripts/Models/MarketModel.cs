using System;
using System.Collections.Generic;
using FishingIdle.Managers.Interfaces;
using FishingIdle.Presenters.Market;

namespace FishingIdle.Models
{
    public class MarketModel
    {
        public event EventHandler<List<InventoryItem>> OnItemListChanged;

        readonly IInventoryManager _inventoryManager;
        readonly ICurrencyManager _currencyManager;

        List<InventoryItem> _itemList = new ();
        
        public MarketModel()
        {
            _inventoryManager = Locator.Instance.Resolve<IInventoryManager>();
            _currencyManager = Locator.Instance.Resolve<ICurrencyManager>();
        }

        public void GetConfig()
        {
            _itemList = _inventoryManager.GetAllItems();
            OnItemListChanged?.Invoke(this, _itemList);
        }
        
        public void SellItem(MarketItemModel item)
        {
            _inventoryManager.RemoveItem(item.itemID);
            _currencyManager.AddCurrency(item.CurrencyType, item.itemPrice);
        }
    }
}