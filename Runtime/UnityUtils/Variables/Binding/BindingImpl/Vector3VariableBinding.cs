using UnityEngine;

namespace UnityUtils.Variables.Binding
{
    public class Vector3VariableBinding : XVariableBinding<Vector3>
    {
        protected override void BindValue() 
            => variable.Value = transform.position;
    }
}