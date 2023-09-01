using System;
using FishingIdle.Managers.Interfaces;

namespace FishingIdle.Managers
{
    public class FishingManager : IFishingManager
    {
        public EventHandler OnEnterFishingZone { get; set; }
        public EventHandler OnExitFishingZone { get; set; }
        public EventHandler<FishCaughtEventArgs> OnFishCaught { get; set; }
        
        public void CatchFish(FishData fishData)
        {
            OnFishCaught?.Invoke(this, new FishCaughtEventArgs(){fishData = fishData});
        }
    }
}