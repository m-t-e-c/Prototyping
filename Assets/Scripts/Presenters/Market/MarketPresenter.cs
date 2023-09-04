using System.Collections.Generic;
using FishingIdle.Managers.Interfaces;
using FishingIdle.Models;
using FishingIdle.Presenters.Market;
using UIElements;
using UnityEngine;

namespace FishingIdle.Presenters
{
    public class MarketPresenter : BasePresenter<MarketPresenter>
    {
        [SerializeField] UITabMenu tabMenu;
        [SerializeField] GameObject sellTabContent;
        [SerializeField] GameObject buyTabContent;

        [SerializeField] MarketItemsScrollPanel marketItemsScrollPanel;

        MarketModel _model;

        ICurrencyManager _currencyManager;
        IInventoryManager _inventoryManager;
        
        protected override void Start()
        {
            base.Start();

            _currencyManager = Locator.Instance.Resolve<ICurrencyManager>();
            _inventoryManager = Locator.Instance.Resolve<IInventoryManager>();
            
            _model = new MarketModel();
            _model.OnItemListChanged += OnItemListLoaded;
            _model.GetConfig();
            CreateTabs();
        }

        void OnItemListLoaded(object sender, List<InventoryItem> e)
        {
            marketItemsScrollPanel.SetData(e, OnBuyClicked, OnSellClicked);
        }

        void OnSellClicked(MarketItemModel obj)
        {
            _inventoryManager.RemoveItem(obj.itemID);
            _currencyManager.AddCurrency(obj.CurrencyType, obj.itemPrice);
        }

        void OnBuyClicked(MarketItemModel obj)
        {
        }

        void CreateTabs()
        {
            tabMenu.CreateTab("SELL",sellTabContent);
            tabMenu.CreateTab("BUY", buyTabContent);
            tabMenu.ChangeSelectedTab(0);
        }

        void OnDestroy()
        {
            _model.OnItemListChanged -= OnItemListLoaded;
        }
    }
}