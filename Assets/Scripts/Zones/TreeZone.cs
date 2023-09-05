using System;
using FishingIdle.Managers;
using UnityEngine;

namespace FishingIdle
{
    public class TreeZone : MonoBehaviour
    {
        [SerializeField] int _durability = 10;
        public bool isChopped = false;

        IPlayerManager _playerManager;

        void Start()
        {
            _playerManager = Locator.Instance.Resolve<IPlayerManager>();
        }

        public void GetDamage(int damage)
        {
            _durability -= damage;
            if (_durability <= 0)
            {
                Chopped();
            }
            DropTreeLog();
        }

        void DropTreeLog()
        {
            Debug.Log("Chopped one");
            // TODO Spawn Tree Log
        }
        
        public void Chopped()
        {
            Debug.Log("Tree Chopped Down");
            isChopped = true;
        }
        
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _playerManager.ChangePlayerState(PlayerStateType.CHOPPING);
                // TODO Show UI
            }
        }
        
        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _playerManager.ChangePlayerState(PlayerStateType.NONE);
                // TODO Hide UI
            }
        }
    }
}