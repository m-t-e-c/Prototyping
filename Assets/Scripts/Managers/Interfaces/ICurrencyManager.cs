using System;

namespace FishingIdle.Managers.Interfaces
{
    public enum CurrencyType
    {
        HardCurrency,
        SoftCurrency
    }
    
    
    public interface ICurrencyManager
    {
        public event EventHandler OnCurrenciesUpdated;
        
        public long GetHardCurrency();
        public long GetSoftCurrency();
        
        public void AddCurrency(CurrencyType currencyType, long amount);
    }
}