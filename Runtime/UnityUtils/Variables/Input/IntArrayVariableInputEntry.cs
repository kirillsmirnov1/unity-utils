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
        private int Value { get; set; } = Int32.MinValue;
        
        public void Fill(IntArrayVariableInput parent, int i, int val)
        {
            _parent = parent;
            _index = i;
            
            if(Value == val) return;
            Value = val;
            input.text = Value.ToString();
        }

        public void OnEdit(string str) 
            => _parent.OnEntryEdit(_index, int.Parse(str));

        public void OnPlusPressed()
        {
            // TODO
        }
        
        public void OnMinusPressed()
        {
            // TODO
        }
        
        public void OnXPressed()
        {
            // TODO
        }
    }
}