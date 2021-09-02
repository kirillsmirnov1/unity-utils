using UnityEngine;

namespace UnityUtils.Variables
{
    [CreateAssetMenu(fileName = "New String Variable", menuName = "Variables/String Variable", order = 0)]
    public class StringVariable : XVariable<string>
    {
        protected override bool SerializedAsJson => false;
    }
}