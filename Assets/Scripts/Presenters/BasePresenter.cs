using FishingIdle.Managers.Interfaces;
using FishingIdle.UIElements;
using UnityEngine;
using Zenject;

namespace FishingIdle.Presenters
{
    public abstract class BasePresenter<T> : MonoBehaviour
    {
        DiContainer _diContainer;
        [SerializeField] private UIButton closeButton;

        IViewManager _viewManager;

        void Start()
        {
            Init();
        }

        void Init()
        {
            _viewManager = Locator.Instance.Resolve<IViewManager>();
            
            closeButton.onClick.AddListener(OnCloseButtonClicked);
        }

        void OnCloseButtonClicked()
        {
            _viewManager?.DestroyView<T>();
        }

        void OnDestroy()
        {
            closeButton.onClick?.RemoveListener(OnCloseButtonClicked);
        }
    }
}