using FishingIdle.UIElements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters.Market
{
    public class MarketItemViewElements : MonoBehaviour
    {
        public Image itemIcon;
        public TextMeshProUGUI itemNameLabel;
        public TextMeshProUGUI itemDescriptionLabel;
        public TextMeshProUGUI itemPriceLabel;
        public TextMeshProUGUI itemRarityLabel;
        public TextMeshProUGUI itemAmountLabel;
        public UIButton buyButton;
        public UIButton sellButton;
    }
}