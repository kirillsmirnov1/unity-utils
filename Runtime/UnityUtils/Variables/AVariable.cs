using System;
using UnityEngine;

namespace UnityUtils.Variables
{
    public abstract class AVariable : ScriptableObject
    {
        public event Action OnChangeBase;
        protected void InvokeOnChangeBase() => OnChangeBase?.Invoke();

        public abstract string Uid { get; }
        public abstract Type Type { get; }
        public abstract bool IsPrimitive { get; }
        public abstract object RawValue { get; }

        public abstract void Set(object value);
    }
}