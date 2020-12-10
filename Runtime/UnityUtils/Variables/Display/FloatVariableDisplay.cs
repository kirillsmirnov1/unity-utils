using UnityEngine;

namespace UnityUtils.Variables.Display
{
    public class FloatVariableDisplay : XVariableDisplay<float>
    {
#pragma warning disable 0649
        [SerializeField] private FloatVariable variable;
#pragma warning restore 0649
        protected override XVariable<float> Variable => variable;
    }
}