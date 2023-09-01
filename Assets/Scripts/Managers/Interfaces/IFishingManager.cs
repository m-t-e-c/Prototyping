using System;

namespace FishingIdle.Managers.Interfaces
{
    public interface IFishingManager
    {
        public EventHandler<FishCaughtEventArgs> OnFishCaught {get; set;}
    }
    
    public class FishCaughtEventArgs : EventArgs
    {
        public FishData fishData;
    }
}