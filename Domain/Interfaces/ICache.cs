namespace Domain.Interfaces
{
    public interface ICache<TKey, TValue>
    {
        TValue Get(TKey key);
        void Set(TKey key, TValue value);
    }
}