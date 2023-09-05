using FishingIdle.Managers.Interfaces;
using FishingIdle.Presenters;
using UnityEngine;

namespace FishingIdle
{
    public class FishingZone : MonoBehaviour
    {
        public string zoneId;
        IViewManager _viewManager;

        void Start()
        {
            _viewManager = Locator.Instance.Resolve<IViewManager>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _viewManager.LoadView(new LoadViewParams<FishingZonePresenter>()
                {
                    viewName = "FishingZoneView",
                    onLoad = presenter => presenter.Init(zoneId)
                });
            }
        }
        
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _viewManager.DestroyView<FishingZonePresenter>();
            }
        }
    }
}