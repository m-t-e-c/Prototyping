using System;
using FishingIdle.Managers.Interfaces;
using UnityEngine;

namespace FishingIdle
{
    public class FishingZone : MonoBehaviour
    {

        [SerializeField] float fishingTime;
        
        bool _isFishing;
        float _fishingTimer;
        
        IFishingManager _fishingManager;


        void Start()
        {
            Init();
        }

        void Init()
        {
            _fishingManager = Locator.Instance.Resolve<IFishingManager>();
        }

        void Update()
        {
            Fishing();
        }

        void Fishing()
        {
            if (!_isFishing)
            {
                return;
            }

            if (_fishingTimer < fishingTime)
            {
                _fishingTimer += Time.deltaTime;
                return;
            }

            _fishingManager.OnFishCaught?.Invoke(this, new FishCaughtEventArgs()
            {
                fishData = new FishData()
                {
                    fishName = "Hamsi",
                    weight = 1.5f,
                    length = 10,
                    price = 100
                }
            });
            _fishingTimer = 0f;
        }
        
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _isFishing = true;
                _fishingManager.OnEnterFishingZone?.Invoke(this,EventArgs.Empty);
            }
        }
        
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _isFishing = false;
                _fishingManager.OnExitFishingZone?.Invoke(this,EventArgs.Empty);
            }
        }
    }
}