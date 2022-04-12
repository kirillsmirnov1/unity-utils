using UnityEngine;

namespace UnityUtils.SO
{
    public abstract class InitiatedScriptableObject : ScriptableObject
    {
        public abstract void Init();
        public virtual void Stop(){}
    }
}