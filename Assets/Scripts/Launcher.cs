using Cysharp.Threading.Tasks;
using DefaultNamespace;
using FishingIdle;
using FishingIdle.Managers;
using FishingIdle.Managers.Interfaces;
using FishingIdle.Services;
using UnityEngine;
using UnityEngine.AddressableAssets;

public class Launcher : MonoBehaviour
{
    IInventoryManager _inventoryManager;
    IMarketManager _marketManager;
    IViewManager _viewManager;
    IFishingZoneManager _fishingZoneManager;
    ICurrencyManager _currencyManager;
    IPlayerManager _playerManager;
    IItemManager _itemManager;
    IPreferencesManager _preferencesManager;
    
    Locator _locator;
    
    const string PlayerAddressableKey = "Player";
    const string CameraAddressableKey = "CameraHolder";
        
    void Awake()
    {
        FIServices.RetrieveCurrencyData();
        FIServices.RetrieveUserInventoryData();
        FIServices.RetrieveFishingZoneData();
        FIServices.RetrieveItemsData();
        InitManagers();
        _viewManager.LoadView(new LoadViewParams<GameplayPresenter>()
        {
           viewName = "GameplayView",
           onLoad = presenter =>
           {
               SpawnPlayerAndCamera(presenter.GetJoystick());
           }
        });
    }
    
    void InitManagers()
    {
        _locator = new Locator();

        _inventoryManager = new InventoryManager();
        _locator.Register<IInventoryManager>(_inventoryManager);
        
        _marketManager = new MarketManager();
        _locator.Register<IMarketManager>(_marketManager);
            
        _viewManager = new ViewManager();
        _locator.Register<IViewManager>(_viewManager);

        _fishingZoneManager = new FishingZoneManager();
        _locator.Register<IFishingZoneManager>(_fishingZoneManager);
        
        _currencyManager = new CurrencyManager();
        _locator.Register<ICurrencyManager>(_currencyManager);
        
        _playerManager = new PlayerManager();
        _locator.Register<IPlayerManager>(_playerManager);
        
        _itemManager = new ItemManager();
        _locator.Register<IItemManager>(_itemManager);
        
        _preferencesManager = new PreferencesManager();
        _locator.Register<IPreferencesManager>(_preferencesManager);
    }

    async void SpawnPlayerAndCamera(Joystick joystick)
    {
        var playerResult = await Addressables.LoadAssetAsync<GameObject>(PlayerAddressableKey);
        GameObject player = Instantiate(playerResult);
        player.GetComponent<PlayerBehaviour>().Init(joystick);
        
        var cameraResult = await Addressables.LoadAssetAsync<GameObject>(CameraAddressableKey);
        GameObject cameraHolder = Instantiate(cameraResult, player.transform.position, Quaternion.identity);
        cameraHolder.GetComponent<CameraFollow>().Init(Camera.main, player.transform, new Vector3(0, 10, -10));
    }

    void OnDestroy()
    {
        _locator.Reset();
    }
}