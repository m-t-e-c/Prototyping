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

        public FishingZoneModel(string zoneID)
        {
            _fishingZoneManager = Locator.Instance.Resolve<IFishingZoneManager>();
            _inventoryManager = Locator.Instance.Resolve<IInventoryManager>();
            _viewManager = Locator.Instance.Resolve<IViewManager>();

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
                    presenter.Init(OnMiniGameCompleted, OnMiniGameCompletedPerfect, 400);
                }
            });
        }

        void OnMiniGameCompleted()
        {
            var fish = _fishingZoneDataOutput.FishList.Find(fish => fish.Rarity == 1);
            _inventoryManager.AddItem(new InventoryItemParams()
            {
                ID = fish.ID,
                Name = fish.FishName,
                Description = fish.Description,
                InventoryItemType = InventoryItemType.FISH,
                IsSellable = true,
                Price = fish.Price,
                CurrencyType = fish.CurrencyType,
                Amount = 1
            });
            OnFishingEnded?.Invoke();
        }

        void OnMiniGameCompletedPerfect()
        {
            var fish = _fishingZoneDataOutput.FishList.Find(fish => fish.Rarity is >= 2 and <= 4);
            _inventoryManager.AddItem(new InventoryItemParams()
            {
                ID = fish.ID,
                Name = fish.FishName,
                Description = fish.Description,
                InventoryItemType = InventoryItemType.FISH,
                IsSellable = true,
                Price = fish.Price,
                CurrencyType = fish.CurrencyType,
                Amount = 1
            });
            OnFishingEnded?.Invoke();
        }

        public void Dispose()
        {
        }
    }
}