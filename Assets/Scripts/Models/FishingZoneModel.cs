using System;
using FishingIdle.Managers.Interfaces;
using FishingIdle.Presenters.MiniGamePresenter;

namespace FishingIdle.Models
{
    public class FishingZoneModel : IDisposable
    {
        public Action OnFishingStarted;
        public Action OnFishingEnded;

        readonly FishingZoneDataOutput _fishingZoneDataOutput;
        readonly IFishingZoneManager _fishingZoneManager;
        readonly IInventoryManager _inventoryManager;
        readonly IViewManager _viewManager;
        readonly IItemManager _itemManager;

        public FishingZoneModel(string zoneID)
        {
            _fishingZoneManager = Locator.Instance.Resolve<IFishingZoneManager>();
            _inventoryManager = Locator.Instance.Resolve<IInventoryManager>();
            _viewManager = Locator.Instance.Resolve<IViewManager>();
            _itemManager = Locator.Instance.Resolve<IItemManager>();

            _fishingZoneDataOutput = _fishingZoneManager.GetFishingZone(zoneID);
        }

        public void StartFishing()
        {
            _viewManager.LoadView(new LoadViewParams<MiniGamePresenter>()
            {
                viewName = "MiniGameView",
                onLoad = presenter =>
                {
                    OnFishingStarted?.Invoke();
                    presenter.Init(OnMiniGameCompleted, OnMiniGameCompleted, 400);
                }
            });
        }

        void OnMiniGameCompleted()
        {
            var filteredFishes = _itemManager
                .GetItems()
                .FindAll(item => item.ItemType == InventoryItemType.FISH &&
                                 item.Rarity >= _fishingZoneDataOutput.MinFishRarity &&
                                 item.Rarity <= _fishingZoneDataOutput.MaxFishRarity && 
                                 item.IsCooked == false);

            var fish = filteredFishes[UnityEngine.Random.Range(0, filteredFishes.Count)];
            _inventoryManager.AddItem(fish, 1);
            OnFishingEnded?.Invoke();
        }


        public void Dispose()
        {
        }
    }
}