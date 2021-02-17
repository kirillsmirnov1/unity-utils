using System;
using UnityEngine;
using UnityUtils.Extensions;

namespace UnityUtils.Variables
{
    // [CreateAssetMenu(fileName = "New X Array Variable", menuName = "Variables/X Array Variable", order = 0)]
    public abstract class XArrayVariable<T> : XVariable<ArrayWrap<T>>
    {
        /// <summary>
        /// index, new value
        /// </summary>
        public event Action<int, T> OnEntryChange;

        protected override void OnValidate()
        {
            if (!Application.isPlaying) return;
            base.OnValidate();
            for (var i = 0; i < Length; i++)
            {
                OnEntryChange?.Invoke(i, Value[i]);
            }
            WriteSave();
        }

        public new T[] Value { 
            get => value.data;
            set
            {
                if (value.Equals(this.value.data)) return;
                this.value.data = value;
                OnDataChanged();   
            }
        }

        public int Length => Value?.Length ?? 0;
        
        public T this[int i]
        {
            get => Value[i];
            set
            {
                if(Value[i].Equals(value)) return;
                Value[i] = value;
                OnEntryChange?.Invoke(i, value);
                WriteSave();
            }
        }
    }
}