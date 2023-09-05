using System;

namespace FishingIdle.Managers
{
    public class PlayerManager : IPlayerManager
    {
        public event EventHandler<PlayerStateType> OnPlayerStateChanged;
        
        public void ChangePlayerState(PlayerStateType playerStateType)
        {
            OnPlayerStateChanged?.Invoke(this, playerStateType);
        }
    }
}