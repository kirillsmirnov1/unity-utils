using UnityEngine;

namespace UnityUtils.Variables.Inject
{
    public class XVariableInject<T> : XVariableInjectRoot
    {
        [SerializeField] protected XVariable<T> variable;
        // Works where T : UnityEngine.Component
        // Needs to be overriden for other cases
        protected override void InjectValue() => variable.Value = GetComponent<T>();
    }
}