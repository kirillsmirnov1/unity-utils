using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.Variables.Input
{
    public class IntArrayVariableInputEntry : MonoBehaviour
    {
        [SerializeField] private InputField input;
        
        private int _index;
        private IntArrayVariableInput _parent;
        private VariableInputProfile _profile;
        private int Value { get; set; } = Int32.MinValue;
        
        public void Fill(IntArrayVariableInput parent, VariableInputProfile profile, int i, int val)
        {
            _parent = parent;
            _profile = profile;
            _index = i;
            
            if(Value == val) return;
            Value = val;
            input.text = Value.ToString();
        }

        public void OnEdit(string str) 
            => _parent.OnEntryEdit(_index, int.Parse(str));

        public void OnPlusPressed() 
            => ChangeValue(Value + _profile.intIterationStep);

        public void OnMinusPressed() 
            => ChangeValue(Value - _profile.intIterationStep);

        private void ChangeValue(int newValue) 
            => _parent.OnEntryEdit(_index, newValue);

        public void OnXPressed() 
            => _parent.RemoveElement(_index);
    }
}