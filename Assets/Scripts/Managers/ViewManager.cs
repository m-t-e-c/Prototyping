using System.Collections.Generic;
using FishingIdle.Managers.Interfaces;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using Object = UnityEngine.Object;

namespace FishingIdle.Managers
{
    public class ViewManager : IViewManager
    {
        readonly Dictionary<string, GameObject> openedViews = new();

        public void LoadView<T>(LoadViewParams<T> loadViewParams)
        {
            if (!openedViews.ContainsKey(loadViewParams.GetViewPresenterType()))
            {
                Addressables.LoadAssetAsync<GameObject>(loadViewParams.viewName).Completed += (obj) =>
                {
                    if (obj.Status == AsyncOperationStatus.Succeeded)
                    {
                        GameObject viewPrefab = obj.Result;
                        GameObject viewInstance = Object.Instantiate(viewPrefab);
                        viewInstance.transform.SetAsLastSibling();
                        openedViews[loadViewParams.GetViewPresenterType()] = viewInstance;
                        loadViewParams.onLoad?.Invoke(viewInstance.GetComponent<T>());
                    }
                };
            }
        }

        public void DestroyView<T>()
        {
            var viewName = typeof(T).Name;
            if (openedViews.ContainsKey(viewName))
            {
                GameObject viewInstance = openedViews[viewName];
                Object.Destroy(viewInstance);
                openedViews.Remove(viewName);
            }
        }
    }
}