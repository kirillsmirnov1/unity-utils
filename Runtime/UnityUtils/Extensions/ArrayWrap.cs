using System;

namespace UnityUtils.Extensions
{
    [Serializable]
    public class ArrayWrap<T>
    {
        public T[] data;
        public int Length => data.Length;
        public T this[int i]
        {
            get => data[i];
            set => data[i] = value;
        }
    }
}