using System;

namespace FishingIdle.Managers.Interfaces
{
    public class LoadViewParams<T> : EventArgs
    {
        public string viewName;
        public Action<T> onLoad;

        readonly string _viewPresenterType;

        public LoadViewParams()
        {
            _viewPresenterType = typeof(T).Name;
        }
        
        public string GetViewPresenterType()
        {
            return _viewPresenterType;
        }
    }
    
    public interface IViewManager
    {
        void LoadView<T>(LoadViewParams<T> loadViewParams);
        void DestroyView<T>();
    }
}