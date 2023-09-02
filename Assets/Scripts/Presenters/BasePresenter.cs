using FishingIdle.Managers.Interfaces;
using FishingIdle.UIElements;
using UnityEngine;
using Zenject;

namespace FishingIdle.Presenters
{
    public abstract class BasePresenter<T> : MonoBehaviour
    {
        [SerializeField] protected RectTransform container;
        [SerializeField] private UIButton closeButton;

        IViewManager _viewManager;

        protected virtual void Start()
        {
            _viewManager = Locator.Instance.Resolve<IViewManager>();
            closeButton?.onClick.AddListener(OnCloseButtonClicked);
        }

        void OnCloseButtonClicked()
        {
           Close();
        }

        protected virtual void Close()
        {
            _viewManager?.DestroyView<T>();
        }

        void OnDestroy()
        {
            closeButton?.onClick.RemoveListener(OnCloseButtonClicked);
        }
    }
}