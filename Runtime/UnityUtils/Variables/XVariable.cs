using System;
using UnityEngine;

namespace UnityUtils.Variables
{
    // [CreateAssetMenu(fileName = "New X Variable", menuName = "Variables/X Variable", order = 0)]
    public abstract class XVariable<T>: ScriptableObject
    {
        public event Action<T> OnChange;
        
#pragma warning disable 0649
        [SerializeField] private T value;
#pragma warning restore 0649

        private void OnValidate() => OnChange?.Invoke(value);

        public T Value
        {
            get => value;
            set
            {
                if(value.Equals(this.value)) return;
                this.value = value;
                OnChange?.Invoke(this.value);
            }
        }
        public static implicit operator T(XVariable<T> v) => v.Value;
        public override string ToString() => Value.ToString();
    }
}