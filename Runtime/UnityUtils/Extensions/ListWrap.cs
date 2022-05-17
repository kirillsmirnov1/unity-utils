using System;
using System.Collections.Generic;

namespace UnityUtils.Extensions
{
    [Serializable]
    public class ListWrap<T>
    {
        public List<T> data;
        public int Length => data.Count;
        public T this[int i]
        {
            get => data[i];
            set => data[i] = value;
        }
    }
}