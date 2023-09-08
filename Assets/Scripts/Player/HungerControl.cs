using System;
using FishingIdle.Managers;
using UnityEngine;

namespace FishingIdle
{
    public class HungerControl : MonoBehaviour
    {
        IPlayerManager _playerManager;

        public float Hunger = 100f;
        public float MaxHunger = 100f;
        public float HungerDecreaseRate = 0.1f;


        void Start()
        {
            _playerManager = Locator.Instance.Resolve<IPlayerManager>();
        }

        void Update()
        {
            Hunger -= HungerDecreaseRate * Time.deltaTime;
            if (Hunger < 0)
            {
                _playerManager.OnStarving?.Invoke(this, EventArgs.Empty);
                Hunger = 0;
            }

            _playerManager.OnHungerLevelChanged?.Invoke(this, Hunger);
        }

        public void EatFood(float foodValue)
        {
            Hunger += foodValue;
            if (Hunger >= MaxHunger)
            {
                Hunger = MaxHunger;
            }
        }
    }
}