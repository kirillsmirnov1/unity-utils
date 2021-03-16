using UnityEngine;

namespace UnityUtils.Variables.Inject
{
    // Non-generic class required to set script execution order
    public abstract class XVariableInjectRoot : MonoBehaviour
    {
        protected virtual void Awake() => InjectValue();
        protected abstract void InjectValue();
    }
}