using UnityEngine;

namespace UnityUtils.Variables.Display
{
    public class IntVariableDisplay : XVariableDisplay<int>
    {
#pragma warning disable 0649
        [SerializeField] private IntVariable variable;
#pragma warning restore 0649
        protected override XVariable<int> Variable => variable;
    }
}