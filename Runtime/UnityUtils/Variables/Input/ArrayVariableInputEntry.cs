using UnityEngine;

namespace UnityUtils.Variables.Input
{
    public abstract class ArrayVariableInputEntry<T> : MonoBehaviour
    {
        protected int Index;
        protected VariableInputProfile Profile;
        protected ArrayVariableInput<T> Parent; // TODO move up 

        private T _value;

        protected T Value
        {
            get => _value;
            set
            {
                if(value.Equals(_value)) return;
                _value = value;
                UpdateValueDisplay(_value);
            }
        }

        public void Fill(ArrayVariableInput<T> parent, VariableInputProfile profile, int i, T val)
        {
            Parent = parent;
            Profile = profile;
            Index = i;
            Value = val;
        }

        protected abstract void UpdateValueDisplay(T newValue);
    }
}