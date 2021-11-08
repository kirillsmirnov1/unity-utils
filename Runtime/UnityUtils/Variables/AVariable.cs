using System;
using UnityUtils.Saves;

namespace UnityUtils.Variables
{
    public abstract class AVariable : InitiatedScriptableObject
    {
        public abstract string SaveFileName { get; }
        public abstract bool IsPrimitive { get; }
        public abstract Type Type { get; }

        public abstract void SetDefaultValue();
        public abstract void Set(object value);
    }
}