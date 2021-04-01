using UnityEngine;

namespace UnityUtils.Variables.Binding
{
    public class XVariableBinding<T> : XVariableBindingRoot
    {
        [SerializeField] protected XVariable<T> variable;
        // Works where T : UnityEngine.Component
        // Needs to be overriden for other cases
        protected override void BindValue() => variable.Value = GetComponent<T>();
        protected override void ClearValue() => variable.Value = default;
    }
}