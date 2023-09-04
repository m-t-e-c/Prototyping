using System;
using FishingIdle.Managers.Interfaces;
using TMPro;
using UnityEngine;

namespace FishingIdle
{
    public class CurrencyPanel : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI hardCurrencyText;
        [SerializeField] TextMeshProUGUI softCurrencyText;
        
        ICurrencyManager _currencyManager;

        void Start()
        {
            _currencyManager = Locator.Instance.Resolve<ICurrencyManager>();
            _currencyManager.OnCurrenciesUpdated += OnCurrenciesUpdated;
            
            UpdateCurrencyTexts();
        }

        void OnCurrenciesUpdated(object sender, EventArgs args)
        {
            UpdateCurrencyTexts();
        }

        void UpdateCurrencyTexts()
        {
            hardCurrencyText.text = _currencyManager.GetHardCurrency().ToString();
            softCurrencyText.text = _currencyManager.GetSoftCurrency().ToString();
        }

        void OnDestroy()
        {
            _currencyManager.OnCurrenciesUpdated -= OnCurrenciesUpdated;
        }
    }
}