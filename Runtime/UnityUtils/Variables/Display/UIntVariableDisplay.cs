using UnityEngine;

namespace UnityUtils.Variables.Display
{
    public class UIntVariableDisplay : XVariableDisplay<uint>
    {
#pragma warning disable 0649
        [SerializeField] private UIntVariable variable;
#pragma warning restore 0649
        protected override XVariable<uint> Variable => variable;
    }
}