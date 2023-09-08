using FishingIdle.UIElements;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Presenters.Market
{
    public class MarketItemViewElements : MonoBehaviour
    {
        public Image itemIcon;
        public Image frameBg;
        public Image sellButtonCurrencyIcon;
        public Image buyButtonCurrencyIcon;
        public GameObject amountHolder;
        public TextMeshProUGUI itemNameLabel;
        public TextMeshProUGUI itemDescriptionLabel;
        public TextMeshProUGUI sellButtonPriceLabel;
        public TextMeshProUGUI buyButtonPriceLabel; 
        public TextMeshProUGUI itemAmountLabel;
        public UIButton buyButton;
        public UIButton sellButton;
        
        public Color32[] rarityColors;

    }
}