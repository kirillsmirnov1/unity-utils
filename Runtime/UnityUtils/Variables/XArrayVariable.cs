using System;

namespace UnityUtils.Variables
{
    // [CreateAssetMenu(fileName = "New X Array Variable", menuName = "Variables/X Array Variable", order = 0)]
    public abstract class XArrayVariable<T> : XVariable<T[]>
    {
        /// <summary>
        /// index, new value
        /// </summary>
        public Action<int, T> OnEntryChange;
        
        public T this[int i]
        {
            get => Value[i];
            set
            {
                if(Value[i].Equals(value)) return;
                Value[i] = value;
                OnEntryChange?.Invoke(i, value);
            }
        }
    }
}