using System;

namespace FishingIdle.Managers.Interfaces
{
    public interface IFishingManager
    {
        public EventHandler OnEnterFishingZone {get; set;}
        public EventHandler OnExitFishingZone {get; set;}
        public EventHandler<FishCaughtEventArgs> OnFishCaught {get; set;}
    }
    
    public class FishCaughtEventArgs : EventArgs
    {
        public FishData fishData;
    }
}