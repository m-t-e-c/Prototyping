using System;

namespace FishingIdle.Managers
{
    public interface IPlayerManager
    {
        public event EventHandler<PlayerStateType> OnPlayerStateChanged;
        
        public void ChangePlayerState(PlayerStateType playerStateType);
    }
}