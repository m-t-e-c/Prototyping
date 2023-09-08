namespace FishingIdle.Managers.Interfaces
{
    public interface IPreferencesManager
    {
        public void Set<T>(string key, T value);
        public T Get<T>(string key);
    }
}