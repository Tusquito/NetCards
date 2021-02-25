using System.Collections.Generic;

namespace NetCards.Api.Core.Managers
{
    public interface IManager<in TKey, T>
    {
        public bool Exists(TKey key);
        public void AddOrUpdate(T obj);
        public void Remove(TKey key);
        public T Get(TKey key);
        public IEnumerable<T> GetAll();
        public void RemoveAll();
    }
}