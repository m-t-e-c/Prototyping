using FishingIdle;
using FishingIdle.Managers;
using FishingIdle.Managers.Interfaces;
using FishingIdle.Services;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    IFishingManager _fishingManager;
    IMarketManager _marketManager;
    IViewManager _viewManager;
    IFishingZoneManager _fishingZoneManager;

    Locator _locator;
        
    void Awake()
    {
        Services.RetrieveData();
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

        _fishingZoneManager = new FishingZoneManager();
        _locator.Register<IFishingZoneManager>(_fishingZoneManager);
    }

    void OnDestroy()
    {
        _locator.Reset();
    }
}