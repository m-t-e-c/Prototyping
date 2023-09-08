using FishingIdle.Managers.Interfaces;
using UnityEngine;

namespace FishingIdle
{
    public class TreeLog : MonoBehaviour
    {
        IInventoryManager _inventoryManager;
        IItemManager _itemManager;

        void Start()
        {
            _inventoryManager = Locator.Instance.Resolve<IInventoryManager>();
            _itemManager = Locator.Instance.Resolve<IItemManager>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                var log = _itemManager.GetItem("wood");
                _inventoryManager.AddItem(log);
                Destroy(gameObject);
            }
        }
    }
}