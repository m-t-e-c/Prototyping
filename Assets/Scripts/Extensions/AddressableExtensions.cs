using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace FishingIdle.Extensions
{
    public static class AddressableExtensions
    {
        public async static UniTask<Sprite> GetCookedFoodIcon(string id)
        {
            string prefix = "";
            string suffix = "_icon";
            var icon = await Addressables.LoadAssetAsync<Sprite>(prefix + id + suffix);

            if (ReferenceEquals(icon,null))
            {
                Debug.LogError("Icon not found for item id: " + id);
                return null;
            }
            return icon;
        }
        
        public async static UniTask<Sprite> GetItemIcon(string id)
        {
            string prefix = "";
            string suffix = "_icon";
            var icon = await Addressables.LoadAssetAsync<Sprite>(prefix + id + suffix);

            if (ReferenceEquals(icon,null))
            {
                Debug.LogError("Icon not found for item id: " + id);
                return null;
            }
            return icon;
        }
    }
}