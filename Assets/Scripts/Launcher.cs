using System;
using FishingIdle.Managers;
using FishingIdle.Managers.Interfaces;
using UnityEngine;

namespace FishingIdle
{
    public class Launcher : MonoBehaviour
    {
        IFishingManager _fishingManager;
        IMarketManager _marketManager;
        IViewManager _viewManager;

        Locator _locator;
        
        void Awake()
        {
            
            Init();
        }

        void Init()
        {
            _locator = new Locator();
            
            _fishingManager = new FishingManager();
            _locator.Register<IFishingManager>(_fishingManager);
            
            _marketManager = new MarketManager();
            _locator.Register<IMarketManager>(_marketManager);
            
            _viewManager = new ViewManager();
            _locator.Register<IViewManager>(_viewManager);
        }

        void OnDestroy()
        {
            _locator.Reset();
        }
    }
}