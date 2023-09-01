using System;
using FishingIdle.Managers.Interfaces;
using FishingIdle.Presenters;
using UnityEngine;

namespace FishingIdle
{
    public class MarketZone : MonoBehaviour
    {
       
        IMarketManager _marketManager;
        IViewManager _viewManager;

        void Start()
        {
            Init();
        }

        void Init()
        {
            _marketManager = Locator.Instance.Resolve<IMarketManager>();
            _viewManager = Locator.Instance.Resolve<IViewManager>();
        }
        
        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _marketManager.OnEnterMarketZone?.Invoke(this, EventArgs.Empty);
                _viewManager.LoadView(new LoadViewParams<TestPresenter>()
                {
                    viewName = "TestView",
                    onLoad = (view) =>
                    {
                        Debug.Log($"View loaded {view}");
                    }
                });
            }
        }
        
        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                _marketManager.OnExitMarketZone?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}