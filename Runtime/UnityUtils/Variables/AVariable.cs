using System;
using UnityEngine;

namespace UnityUtils.Variables
{
    public abstract class AVariable : ScriptableObject
    {
        public event Action OnChangeBase;
        public abstract string Uid { get; }
        public abstract bool IsPrimitive { get; }
        public abstract Type Type { get; }
        public abstract object RawValue { get; }
        
        public abstract void Set(object value);

        protected void InvokeOnChangeBase() => OnChangeBase?.Invoke();
    }
}