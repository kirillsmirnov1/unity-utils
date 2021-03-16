using UnityEngine;

namespace UnityUtils.Variables.Inject
{
    public abstract class XVariableInjectRoot : MonoBehaviour
    {
        protected virtual void Awake() => InjectValue();
        protected abstract void InjectValue();
    }
}