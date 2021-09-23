using System;
using UnityEngine;

namespace UnityUtils
{
    [Serializable]
    public struct Observable<T>
    {
        public event Action<T> OnChange;
        
        [SerializeField] private T value;
        public T Value
        {
            get => value;
            set
            {
                if(value.Equals(this.value)) return;
                this.value = value;
                OnChange?.Invoke(value);
            }
        }

        public static implicit operator T(Observable<T> observable) 
            => observable.value;
    }
}