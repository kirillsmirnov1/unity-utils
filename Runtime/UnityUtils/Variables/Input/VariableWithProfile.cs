using System;

namespace UnityUtils.Variables.Input
{
    [Serializable]
    public struct VariableWithProfile
    {
        public AVariable variable;
        public VariableInputProfile profileOverride;
    }
}