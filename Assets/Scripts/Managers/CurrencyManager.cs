using System;
using FishingIdle.Managers.Interfaces;
using FishingIdle.Services;
using UnityEngine;

namespace FishingIdle.Managers
{
    public class CurrencyManager : ICurrencyManager
    {
        public event EventHandler OnCurrenciesUpdated;

        CurrencyDataOutput _currencyDataOutput;

        public CurrencyManager()
        {
            GetConfig();
        }
        
        void GetConfig()
        {
            _currencyDataOutput = FIServices.GetCurrencyDataOutput();
            OnCurrenciesUpdated?.Invoke(this, EventArgs.Empty);
        }
        
        public long GetHardCurrency()
        {
            if (ReferenceEquals(_currencyDataOutput, null))
            {
                Debug.LogError("CurrencyDataOutput is null. Did you forget to call GetConfig()?");
                return 0;
            }
            return _currencyDataOutput.HardCurrency;
        }

        public long GetSoftCurrency()
        {
            if (ReferenceEquals(_currencyDataOutput, null))
            {
                Debug.LogError("CurrencyDataOutput is null. Did you forget to call GetConfig()?");
                return 0;
            }
            return _currencyDataOutput.SoftCurrency;
        }

        public void AddCurrency(CurrencyType currencyType, long amount)
        {
            if (ReferenceEquals(_currencyDataOutput, null))
            {
                Debug.LogError("CurrencyDataOutput is null. Did you forget to call GetConfig()?");
                return;
            }

            if (currencyType.Equals(CurrencyType.HardCurrency))
            {
                _currencyDataOutput.HardCurrency += amount;
            }
            else if(currencyType.Equals(CurrencyType.SoftCurrency))
            {
                _currencyDataOutput.SoftCurrency += amount;
            }
            
            OnCurrenciesUpdated?.Invoke(this, EventArgs.Empty);
            FIServices.SaveCurrencyData(_currencyDataOutput);
        }
    }
}