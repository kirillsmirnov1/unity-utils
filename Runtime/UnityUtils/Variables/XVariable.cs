using UnityEngine;

namespace UnityUtils.Variables
{
    // [CreateAssetMenu(fileName = "New X Variable", menuName = "Variables/X Variable", order = 0)]
    public abstract class XVariable<T>: ScriptableObject
    {
        public T value;
        public static implicit operator T(XVariable<T> v) => v.value;
        public override string ToString() => value.ToString();
    }
}