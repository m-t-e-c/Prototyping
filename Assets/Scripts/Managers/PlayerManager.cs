using System;

namespace FishingIdle.Managers
{
    public class PlayerManager : IPlayerManager
    {
        public EventHandler<float> OnHungerLevelChanged { get; set; }
        public EventHandler OnStarving { get; set; }
        public event EventHandler<PlayerStateType> OnPlayerStateChanged;
        
        float _hungerLevel = 100f;
        
        public void ChangePlayerState(PlayerStateType playerStateType)
        {
            OnPlayerStateChanged?.Invoke(this, playerStateType);
        }
    }
}