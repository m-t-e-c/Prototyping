using System;
using System.Collections.Generic;
using FishingIdle.Managers.Interfaces;
using UnityEngine;

namespace FishingIdle.Models
{
    public class PlayerModel : IDisposable
    {
        readonly List<FishData> _caughtFish = new();

        readonly IMarketManager _marketManager;
        readonly IFishingManager _fishingManager;

        public PlayerModel()
        {
            _marketManager = Locator.Instance.Resolve<IMarketManager>();
            _fishingManager = Locator.Instance.Resolve<IFishingManager>();

            _marketManager.OnEnterMarketZone += SellAllFishes;
            _fishingManager.OnFishCaught += CaughtFish;
        }

        public void CaughtFish(object sender, FishCaughtEventArgs fishCaughtEventArgs)
        {
            _caughtFish.Add(fishCaughtEventArgs.fishData);
            Debug.Log(
                $"Fish caught: {fishCaughtEventArgs.fishData.fishName} - {fishCaughtEventArgs.fishData.weight} - {fishCaughtEventArgs.fishData.length} - {fishCaughtEventArgs.fishData.price}");
        }

        void SellAllFishes(object sender, EventArgs e)
        {
            _marketManager.SellFishes(_caughtFish);
            _caughtFish.Clear();
        }

        public void Dispose()
        {
            _marketManager.OnEnterMarketZone -= SellAllFishes;
            _fishingManager.OnFishCaught -= CaughtFish;
        }
    }
}