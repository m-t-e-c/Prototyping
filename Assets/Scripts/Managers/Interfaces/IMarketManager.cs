using System;
using System.Collections.Generic;

namespace FishingIdle.Managers.Interfaces
{
    public interface IMarketManager
    {
        public EventHandler OnEnterMarketZone { get; set; }
        public EventHandler OnExitMarketZone { get; set; }
        public EventHandler OnFishesSold { get; set; }
        
        public void SellFishes(List<FishData> fishList);
    }
}