using System;

namespace Utils
{
    [Serializable]
    public class KeyValue<TKey, TValue>
    {
        public TKey key;
        public TValue value;
    }
}