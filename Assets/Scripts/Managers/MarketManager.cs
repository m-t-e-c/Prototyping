using System;
using System.Collections.Generic;
using FishingIdle.Managers.Interfaces;
using UnityEngine;

namespace FishingIdle.Managers
{
    public class MarketManager : IMarketManager
    {
        public EventHandler OnEnterMarketZone { get; set; }
        public EventHandler OnExitMarketZone { get; set; }
        public EventHandler OnFishesSold { get; set; }
        
        public void SellFishes(List<FishData> fishList)
        {
            foreach (FishData fishData in fishList)
            {
                Debug.Log($"Fish sold: {fishData.fishName} - {fishData.weight} - {fishData.length} - {fishData.price}");
            }    
        }
    }
}