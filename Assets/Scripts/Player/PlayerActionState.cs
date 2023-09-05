using UnityEngine;

namespace FishingIdle
{
    public enum PlayerStateType
    {
        NONE,
        FISHING,
        CHOPPING,
        MINING
    }
    
    public abstract class PlayerActionState : MonoBehaviour
    {
        public PlayerStateType playerStateType;

        public abstract void OnEnterState();
        public abstract void OnExitState();
        public abstract PlayerStateType OnUpdateState();
    }
}