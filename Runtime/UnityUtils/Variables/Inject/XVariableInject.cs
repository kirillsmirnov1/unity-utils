using UnityEngine;

namespace UnityUtils.Variables.Inject
{
    public class XVariableInject<T> : XVariableInjectRoot
    {
        [SerializeField] private XVariable<T> variable;
        protected override void InjectValue() => variable.Value = GetComponent<T>();
    }
}