using UnityEngine;

namespace UnityUtils.Variables.Binding
{
    // Non-generic class required to set script execution order
    public abstract class XVariableBindingRoot : MonoBehaviour
    {
        protected virtual void Awake() => BindValue();
        protected void OnDestroy() => ClearValue();
        protected abstract void BindValue();
        protected abstract void ClearValue();
    }
}