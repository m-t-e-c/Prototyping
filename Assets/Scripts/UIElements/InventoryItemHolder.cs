using FishingIdle.Managers.Interfaces;
using TMPro;
using UnityEngine;

namespace FishingIdle
{
    public class InventoryItemHolder : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI itemName;
        [SerializeField] TextMeshProUGUI itemAmount;
        
        public void Init(InventoryItem item)
        {
            itemName.text = item.ItemName;
            itemAmount.text = item.ItemCount.ToString();
        }
    }
}