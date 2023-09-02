using FishingIdle.Managers.Interfaces;
using FishingIdle.Models;
using UnityEngine;


namespace FishingIdle.Presenters
{
    public class InventoryPresenter : BasePresenter<InventoryPresenter>
    {
        [SerializeField] GameObject inventoryItemHolderPrefab;
        [SerializeField] RectTransform itemsParent;
        InventoryModel _model;

        protected override void Start()
        {
            base.Start();
            _model = new InventoryModel();
            CreateInventory();
        }

        void CreateInventory()
        {
            foreach (InventoryItem item in _model.itemList)
            {
                var itemHolderPrefab = Instantiate(inventoryItemHolderPrefab, itemsParent);
                var itemHolder = itemHolderPrefab.GetComponent<InventoryItemHolder>();
                itemHolder.Init(item);
            }
        }
    }
}