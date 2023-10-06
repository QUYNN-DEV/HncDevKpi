using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;

namespace DEV_KPI.Common.Reflector
{
    public sealed class GenericCache<TKey, TValue>
    {
        private readonly IDictionary<TKey, object> entries;

        private Func<TKey, TValue> _funcInitData = null;

        public int Count => ClearCollected();

        public TValue this[TKey key]
        {
            get
            {
                return Get(key);
            }
            set
            {
                Insert(key, value);
            }
        }

        public GenericCache(Func<TKey, TValue> funcInitData = null)
        {
            entries = new ConcurrentDictionary<TKey, object>();
            _funcInitData = funcInitData;
        }

        public GenericCache(IEqualityComparer<TKey> equalityComparer)
        {
            entries = new ConcurrentDictionary<TKey, object>(equalityComparer);
        }

        public void Insert(TKey key, TValue value)
        {
            entries[key] = value;
        }

        public TValue Get(TKey key)
        {
            if (!entries.TryGetValue(key, out object obj))
            {
                if (_funcInitData == null)
                {
                    return default(TValue);
                }
                TValue val = _funcInitData(key);
                Insert(key, val);
                obj = val;
            }
            WeakReference weakReference = obj as WeakReference;
            return (TValue)((weakReference != null) ? weakReference.Target : obj);
        }

        public bool Remove(TKey key)
        {
            return entries.Remove(key);
        }

        public void Clear()
        {
            entries.Clear();
        }

        private int ClearCollected()
        {
            List<TKey> list = Enumerable.ToList<TKey>(Enumerable.Select<KeyValuePair<TKey, object>, TKey>(Enumerable.Where<KeyValuePair<TKey, object>>((IEnumerable<KeyValuePair<TKey, object>>)entries, (Func<KeyValuePair<TKey, object>, bool>)((KeyValuePair<TKey, object> kvp) => kvp.Value is WeakReference && !(kvp.Value as WeakReference).IsAlive)), (Func<KeyValuePair<TKey, object>, TKey>)((KeyValuePair<TKey, object> kvp) => kvp.Key)));
            list.ForEach(delegate (TKey k)
            {
                entries.Remove(k);
            });
            return entries.Count;
        }

        public override string ToString()
        {
            int num = ClearCollected();
            return (num > 0) ? $"Cache contains {num} live objects." : "Cache is empty.";
        }
    }
}
