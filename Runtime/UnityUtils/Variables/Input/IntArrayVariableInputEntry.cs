using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.Variables.Input
{
    public class IntArrayVariableInputEntry : ArrayVariableInputEntry<int>
    {
        [SerializeField] private InputField input;

        private IntArrayVariableInput _parent; // TODO move up 
        private int Value { get; set; } = Int32.MinValue;
        
        public void Fill(IntArrayVariableInput parent, VariableInputProfile profile, int i, int val)
        {
            base.Fill(profile, i);
            _parent = parent;

            if(Value == val) return;
            Value = val;
            input.text = Value.ToString();
        }

        public void OnEdit(string str) 
            => _parent.OnEntryEdit(Index, int.Parse(str));

        public void OnPlusPressed() 
            => ChangeValue(Value + Profile.intIterationStep);

        public void OnMinusPressed() 
            => ChangeValue(Value - Profile.intIterationStep);

        private void ChangeValue(int newValue) 
            => _parent.OnEntryEdit(Index, newValue);

        public void OnXPressed() 
            => _parent.RemoveElement(Index);
    }
}