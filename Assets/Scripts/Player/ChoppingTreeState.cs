using System;
using UnityEngine;

namespace FishingIdle
{
    public class ChoppingTreeState : PlayerActionState
    {
        public float choppingTime = 1f;
        public int choppingForce = 1;
        
        float timer = 0f;

        TreeZone _treeZone;
        
        public override void OnEnterState()
        {
            Debug.Log($"{playerStateType} Entered!");
        }

        public override void OnExitState()
        {
            Debug.Log($"{playerStateType} Exit!");
        }

        public override PlayerStateType OnUpdateState()
        {
        
            if (ReferenceEquals(_treeZone, null) || _treeZone.isChopped)
            {
                return PlayerStateType.NONE;
            }
            
            timer += Time.deltaTime;
            if (timer >= choppingTime)
            {
                timer = 0;
                _treeZone.GetDamage(choppingForce);
            }
            
            return playerStateType;
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out TreeZone treeZone))
            {
                _treeZone = treeZone;
            }
        }
        
        void OnTriggerExit(Collider other)
        {
            if (other.TryGetComponent(out TreeZone treeZone))
            {
                if (_treeZone.Equals(treeZone))
                {
                    _treeZone = null;
                }
            }
        }
    }
}