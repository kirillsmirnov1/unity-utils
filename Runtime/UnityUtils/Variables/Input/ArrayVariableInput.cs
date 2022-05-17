using UnityEngine;

namespace UnityUtils.Variables.Input
{
    public abstract class ArrayVariableInput<T> : VariableInput
    {
        [SerializeField] protected RectTransform entryRoot;
        
        protected RectTransform Rect;

        public override void Fill(AVariable variable, VariableInputProfile profile)
        {
            base.Fill(variable, profile);
            Rect = GetComponent<RectTransform>();
        }
    }
}