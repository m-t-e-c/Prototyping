using System;
using FishingIdle.Managers;
using FishingIdle.Managers.Interfaces;
using FishingIdle.Presenters;
using UniRx;

namespace FishingIdle.Models
{
    public class GameplayModel : IDisposable
    {
        public readonly ReactiveProperty<float> HungerLevel = new();
        public readonly ReactiveProperty<bool> IsStarving = new();
        
        readonly IViewManager _viewManager;
        readonly IPlayerManager _playerManager;

        public GameplayModel()
        {
            _viewManager = Locator.Instance.Resolve<IViewManager>();
            _playerManager = Locator.Instance.Resolve<IPlayerManager>();
            
            _playerManager.OnHungerLevelChanged += OnHungerLevelChanged;
            _playerManager.OnStarving += OnStarving;
        }

        void OnHungerLevelChanged(object sender, float hungerLevel)
        {
            if (hungerLevel > 0)
            {
                IsStarving.Value = false;
            }
            HungerLevel.Value = hungerLevel;
        }

        void OnStarving(object sender, EventArgs args)
        {
            IsStarving.Value = true;
        }

        public void ShowInventory()
        {
            _viewManager.LoadView(new LoadViewParams<InventoryPresenter>()
            {
                viewName = "InventoryView"
            });
        }

        public void Dispose()
        {
            HungerLevel?.Dispose();
            IsStarving?.Dispose();
            _playerManager.OnHungerLevelChanged -= OnHungerLevelChanged;
        }
    }
}