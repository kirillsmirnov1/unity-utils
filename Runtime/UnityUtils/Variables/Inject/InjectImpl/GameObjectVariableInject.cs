using UnityEngine;

namespace UnityUtils.Variables.Inject
{
    public class GameObjectVariableInject : XVariableInject<GameObject>
    {
        protected override void InjectValue() => variable.Value = gameObject;
    }
}