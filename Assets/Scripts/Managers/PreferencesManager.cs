using FishingIdle.Managers.Interfaces;
using UnityEngine;

namespace FishingIdle.Managers
{
    public class PreferencesManager : IPreferencesManager
    {
        public void Set<T>(string key, T value)
        {
            string jsonValue = JsonUtility.ToJson(value);
            PlayerPrefs.SetString(key, jsonValue);
            PlayerPrefs.Save();
        }

        public T Get<T>(string key)
        {
            if (PlayerPrefs.HasKey(key))
            {
                string jsonValue = PlayerPrefs.GetString(key);
                return JsonUtility.FromJson<T>(jsonValue);
            }

            return default(T);
        }
    }
}