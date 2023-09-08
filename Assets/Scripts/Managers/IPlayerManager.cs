using System;

namespace FishingIdle.Managers
{
    public interface IPlayerManager
    {
        public  EventHandler<float> OnHungerLevelChanged { get; set; } 
        public  EventHandler OnStarving { get; set; }
        
        public event EventHandler<PlayerStateType> OnPlayerStateChanged;
        
        public void ChangePlayerState(PlayerStateType playerStateType);
    }
}