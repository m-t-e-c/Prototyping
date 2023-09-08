using System;
using System.Collections.Generic;
using Com.TheFallenGames.OSA.Core;
using Com.TheFallenGames.OSA.DataHelpers;
using Com.TheFallenGames.OSA.Demos.SimpleMultiplePrefabs.ViewsHolders;
using FishingIdle.Managers.Interfaces;
using Presenters.Market;
using UnityEngine;

namespace FishingIdle.Presenters.Market
{
    public class MarketItemsScrollPanel : OSA<MyParams, MarketItemViewsHolder>
    {
        SimpleDataHelper<MarketItemModel> _data;
        List<InventoryItem> _items = new();

        Action<MarketItemModel> _onSellClicked;
        Action<MarketItemModel> _onBuyClicked;

        protected override void Awake()
        {
            base.Awake();
            _data = new SimpleDataHelper<MarketItemModel>(this);
        }

        protected override void Start()
        {
            base.Start();
            BindData();
        }

        void BindData()
        {
            for (var i = 0; i < _items.Count; i++)
            {
                var item = _items[i];
                var marketItemModel = new MarketItemModel()
                {
                    index = i,
                    itemID = item.ItemData.ID,
                    itemName = item.ItemData.ItemName,
                    itemDescription = item.ItemData.Description,
                    itemPrice = item.ItemData.Price,
                    itemAmount = item.ItemAmount,
                    itemRarity = item.ItemData.Rarity,
                    itemType = item.ItemData.ItemType,
                    CurrencyType = item.ItemData.CurrencyType,
                };
                _data.InsertOneAtEnd(marketItemModel);
            }
        }

        protected override MarketItemViewsHolder CreateViewsHolder(int itemIndex)
        {
            var marketItemViewsHolder = new MarketItemViewsHolder();
            marketItemViewsHolder.Init(_Params.prefab, _Params.Content, itemIndex);
            return marketItemViewsHolder;
        }

        protected override void UpdateViewsHolder(MarketItemViewsHolder newOrRecycled)
        {
            var model = _data[newOrRecycled.ItemIndex];
            newOrRecycled.UpdateView(model, OnBuyClicked, OnSellClicked);
        }

        public void SetData(List<InventoryItem> items, Action<MarketItemModel> onBuyClicked = null,
            Action<MarketItemModel> onSellClicked = null)
        {
            _items = items;
            _onSellClicked = onSellClicked;
            _onBuyClicked = onBuyClicked;
        }

        void OnSellClicked(MarketItemModel itemModel)
        {
            if (itemModel.itemAmount < 1)
            {
                _data.RemoveItems(itemModel.index, 1);
            }
            
            Refresh();
            _data.NotifyListChangedExternally();
            _onSellClicked?.Invoke(itemModel);
        }

        void OnBuyClicked(MarketItemModel obj)
        {
            _onBuyClicked?.Invoke(obj);
        }
    }

    public class MarketItemModel
    {
        public int index;
        public string itemID;
        public string itemName;
        public string itemDescription;
        public long itemPrice;
        public int itemAmount;
        public ItemRarity itemRarity;
        public InventoryItemType itemType;
        public CurrencyType CurrencyType;
        public Action<MarketItemModel> onBuyClicked;
        public Action<MarketItemModel> onSellClicked;
    }

    public class MarketItemViewsHolder : SimpleBaseVH
    {
        MarketItemModel _model;
        MarketItemViewElements _viewElements;

        public override void CollectViews()
        {
            base.CollectViews();
            _viewElements = root.GetComponent<MarketItemViewElements>();
        }

        public override bool CanPresentModelType(Type modelType)
        {
            return modelType == typeof(MarketItemModel);
        }

        public void UpdateView(MarketItemModel model, Action<MarketItemModel> onBuyClicked = null,
            Action<MarketItemModel> onSellClicked = null)
        {
            _model = model;
            _viewElements.buyButton.onClick.RemoveAllListeners();
            _viewElements.sellButton.onClick.RemoveAllListeners();
            _viewElements.buyButton.onClick.AddListener(() =>
            {
                onBuyClicked?.Invoke(_model);
                UpdateInfo();
            });

            _viewElements.sellButton.onClick.AddListener(() =>
            {
                _model.itemAmount -= 1;
                onSellClicked?.Invoke(_model);
                UpdateInfo();
            });

            UpdateInfo();
        }

        void UpdateInfo()
        {
            _viewElements.itemNameLabel.text = _model.itemName;
            _viewElements.itemDescriptionLabel.text = _model.itemDescription;
            _viewElements.sellButtonPriceLabel.text = _model.itemPrice.ToString();
            _viewElements.buyButtonPriceLabel.text = _model.itemPrice.ToString();
            _viewElements.amountHolder.SetActive(_model.itemAmount > 1);
            _viewElements.frameBg.color = _model.itemRarity switch
            {
                ItemRarity.COMMON => _viewElements.rarityColors[0],
                ItemRarity.UNCOMMON => _viewElements.rarityColors[1],
                ItemRarity.RARE => _viewElements.rarityColors[2],
                ItemRarity.EPIC => _viewElements.rarityColors[3],
                ItemRarity.LEGENDARY => _viewElements.rarityColors[4],
                ItemRarity.MYTHIC => _viewElements.rarityColors[5],
                ItemRarity.GODLY => _viewElements.rarityColors[5],
                ItemRarity.SPECIAL => _viewElements.rarityColors[5],
                _ => _viewElements.rarityColors[5]
            };

            _viewElements.itemAmountLabel.text = _model.itemAmount.ToString();
        }
    }

    [Serializable]
    public class MyParams : BaseParams
    {
        public GameObject prefab;
    }
}