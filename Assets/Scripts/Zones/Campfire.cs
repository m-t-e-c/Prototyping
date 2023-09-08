using FishingIdle.Managers.Interfaces;
using Presenters.Campfire;
using UnityEngine;

namespace FishingIdle
{
    public class Campfire : MonoBehaviour
    {
        IViewManager _viewManager;

        void Start()
        {
            _viewManager = Locator.Instance.Resolve<IViewManager>();
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _viewManager.LoadView(new LoadViewParams<CampfirePresenter>()
                {
                    viewName = "CampfireView",
                });
            }
        }
        
        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _viewManager.DestroyView<CampfirePresenter>();
            }
        }
    }
}