namespace CustomCacheProvider
{
    public interface ICustomCacheManager
    {
        void Add<T>(T addObject, string key, int seconds);

        void Remove(string key);

        T Get<T>(string key);
    }
}