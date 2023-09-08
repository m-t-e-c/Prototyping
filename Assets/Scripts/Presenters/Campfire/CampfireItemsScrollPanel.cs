using System;
using System.Collections.Generic;
using Com.TheFallenGames.OSA.Core;
using Com.TheFallenGames.OSA.CustomAdapters.GridView;
using Com.TheFallenGames.OSA.DataHelpers;
using Com.TheFallenGames.OSA.Demos.GridDifferentItemSizes;
using Com.TheFallenGames.OSA.Demos.SimpleMultiplePrefabs.Models;
using FishingIdle;
using FishingIdle.Managers.Interfaces;
using UnityEngine;

namespace Presenters.Campfire
{
    public class CampfireItemsScrollPanel : GridAdapter<GridParams, CampfireItemViewsHolder>
    {
        SimpleDataHelper<CampfireItemModel> _data;
        List<InventoryItem> _items = new();

        Action<ItemDataOutput> _onCookClicked;

        protected override void Awake()
        {
            base.Awake();
            _data = new SimpleDataHelper<CampfireItemModel>(this);
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
                var campfireItemModel = new CampfireItemModel()
                {
                    index = i,
                    itemAmount = item.ItemAmount,
                    itemData = item.ItemData,
                };
                _data.InsertOneAtEnd(campfireItemModel);
            }
        }

        protected override void UpdateCellViewsHolder(CampfireItemViewsHolder viewsHolder)
        {
            var model = _data[viewsHolder.ItemIndex];
            viewsHolder.UpdateView(model, (cookItem) => _onCookClicked?.Invoke(cookItem.itemData));
        }


        public void RemoveItem(ItemDataOutput item)
        {
            CampfireItemModel itemModel = null;
            foreach (CampfireItemModel model in _data)
            {
                if (model.itemData.ID == item.ID)
                {
                    itemModel = model;
                    break;
                }
            }

            if (itemModel.itemAmount < 1)
            {
                _data.RemoveItems(itemModel.index, 1);
            }

            Refresh();
            _data.NotifyListChangedExternally();
        }

        public void SetData(List<InventoryItem> items, Action<ItemDataOutput> onCookClicked)
        {
            _items = items;
            _onCookClicked = onCookClicked;
        }
    }

    public class CampfireItemViewsHolder : CellViewsHolder
    {
        CampFireItemViewElements _viewElements;

        CampfireItemModel _model;

        protected override RectTransform GetViews()
        {
            var v = root.Find("Views").GetComponent<RectTransform>();
            _viewElements = v.GetComponent<CampFireItemViewElements>();
            return v;
        }

        public void UpdateView(CampfireItemModel model, Action<CampfireItemModel> onCookClicked)
        {
            _model = model;
            _viewElements.cookButton.onClick.RemoveAllListeners();
            _viewElements.cookButton.onClick.AddListener(() =>
            {
                _model.itemAmount--;
                onCookClicked?.Invoke(model);
                UpdateInfo();
            });

            UpdateInfo();
        }

        void UpdateInfo()
        {
            _viewElements.energyAmountLabel.text = _model.itemData.Energy.ToString("0");
            _viewElements.hungerAmountLabel.text = _model.itemData.Hunger.ToString("0");
            _viewElements.itemAmountLabel.text = _model.itemAmount.ToString("0");
        }
    }

    public class CampfireItemModel : SimpleBaseModel
    {
        public int index;
        public int itemAmount;
        public ItemDataOutput itemData;
    }

    [Serializable]
    public class MyParams : MyGridParams
    {
        public GameObject prefab;
    }
}