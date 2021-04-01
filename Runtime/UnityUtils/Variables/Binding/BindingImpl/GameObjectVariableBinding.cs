using UnityEngine;

namespace UnityUtils.Variables.Binding
{
    public class GameObjectVariableBinding : XVariableBinding<GameObject>
    {
        protected override void BindValue() => variable.Value = gameObject;
    }
}