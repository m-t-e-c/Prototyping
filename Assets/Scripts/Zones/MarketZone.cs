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
                _viewManager.LoadView(new LoadViewParams<MarketPresenter>()
                {
                    viewName = "MarketView",
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
                _viewManager.DestroyView<MarketPresenter>();
            }
        }
    }
}