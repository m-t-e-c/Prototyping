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

      
        
        protected override void Start()
        {
            base.Start();
            _model = new MarketModel();
            _model.OnItemListChanged += OnItemListLoaded;
            _model.GetConfig();
            CreateTabs();
        }

        void OnItemListLoaded(object sender, List<InventoryItem> e)
        {
            marketItemsScrollPanel.SetData(e, null, _model.SellItem);
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