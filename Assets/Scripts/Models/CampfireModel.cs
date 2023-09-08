using System;
using System.Collections.Generic;
using DG.Tweening;
using FishingIdle.Managers.Interfaces;
using UniRx;

namespace FishingIdle.Models
{
    public class CampfireModel : IDisposable
    {
        public readonly ReactiveProperty<float> CookingTime = new();
        public event EventHandler<ItemDataOutput> OnCookingFinished;

        readonly List<InventoryItem> _items;

        readonly IInventoryManager _inventoryManager;
        readonly IItemManager _itemManager;

        ItemDataOutput _currentCookingItem;
        ItemDataOutput _cookedItem;

        public CampfireModel()
        {
            _inventoryManager = Locator.Instance.Resolve<IInventoryManager>();
            _itemManager = Locator.Instance.Resolve<IItemManager>();

            _items = _inventoryManager.GetAllItems().FindAll(item => item.ItemData.IsCookable);
        }

        public List<InventoryItem> GetItems()
        {
            return _items;
        }
        
        public void CollectCookedFood()
        {
            _inventoryManager.AddItem(_cookedItem);
            _currentCookingItem = null;
            _cookedItem = null;
        }

        public void CookItem(ItemDataOutput cookItem, Action onCookingStarted, Action onCookingFailed)
        {
            if (!ReferenceEquals(_currentCookingItem, null))
            {
                onCookingFailed?.Invoke();
                return;
            }

            _currentCookingItem = cookItem;
            _inventoryManager.RemoveItem(cookItem.ID);
            onCookingStarted?.Invoke();

            float cookingTime = 0f;
            DOTween.To(() => cookingTime, x => cookingTime = x, 1f, 5f)
                .OnUpdate(() =>
                {
                    CookingTime.Value = cookingTime;
                })
                .OnComplete(() =>
                {
                    _cookedItem = _itemManager.GetCookedItem(_currentCookingItem);
                    OnCookingFinished?.Invoke(this, _cookedItem);
                });
        }

        public void Dispose()
        {
            CookingTime?.Dispose();
        }
    }
}