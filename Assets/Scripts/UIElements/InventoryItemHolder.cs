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
            itemName.text = item.ItemData.ItemName;
            itemAmount.text = item.ItemAmount.ToString();
        }
    }
}