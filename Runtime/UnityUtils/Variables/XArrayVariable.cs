using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils.Extensions;
using Random = UnityEngine.Random;

namespace UnityUtils.Variables
{
    // [CreateAssetMenu(fileName = "New X Array Variable", menuName = "Variables/Array/X Array Variable", order = 0)]
    public abstract class XArrayVariable<T> : XVariable<ArrayWrap<T>>
    {
        /// <summary>
        /// index, new value
        /// </summary>
        public event Action<int, T> OnEntryChange;
        
#if UNITY_EDITOR
        protected override void OnValidate()
        {
            base.OnValidate();
            if (Application.isPlaying)
            {
                for (var i = 0; i < Length; i++)
                {
                    OnEntryChange?.Invoke(i, Value[i]);
                }
            }
        }
#endif

        public new List<T> Value { 
            get => value.data;
            set
            {
                if (value.Equals(this.value.data)) return;
                this.value.data = value;
                OnDataChanged();   
            }
        }

        public void Add(T val)
        {
            value.data.Add(val);
            OnDataChanged();
        }

        public int Length => Value?.Count ?? 0;
        
        public T this[int i]
        {
            get => Value[i];
            set
            {
                if(Value[i].Equals(value)) return;
                Value[i] = value;
                OnEntryChange?.Invoke(i, value);
                OnDataChanged();
            }
        }

        public T RandomEntry => value[Random.Range(0, Length)];
    }
}