using System;

namespace UnityUtils.Variables
{
    // [CreateAssetMenu(fileName = "New X Array Variable", menuName = "Variables/X Array Variable", order = 0)]
    public abstract class XArrayVariable<T> : XVariable<T[]>
    {
        /// <summary>
        /// index, new value
        /// </summary>
        public event Action<int, T> OnEntryChange;

        protected override void OnValidate()
        {
            base.OnValidate();
            for (var i = 0; i < Value.Length; i++)
            {
                OnEntryChange?.Invoke(i, Value[i]);
            }
        }

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