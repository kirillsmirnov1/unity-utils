using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.Variables.Input
{
    public class StringVariableInput : VariableInput
    {
        public override Type VariableType => typeof(string);
    
        [SerializeField] private InputField text;

        private new StringVariable Variable 
            => (StringVariable) base.Variable;

        private string Value
        {
            get => Variable.Value;
            set => Variable.Value = value; 
        }

        public override void Fill(AVariable variable, VariableInputProfile profile)
        {
            base.Fill(variable, profile);
            SetValue(Value);
            Variable.OnChange += SetValue;
        }

        private void OnDestroy()
        {
            Variable.OnChange -= SetValue;
        }

        private void SetValue(string str)
        {
            if(str == text.text) return;
            text.text = str;
        }

        public void OnEdit(string str) => Value = str;
    }
}