using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.Variables.Input
{
    public class StringVariableInput : VariableInput
    {
        [SerializeField] private InputField text;

        private new StringVariable Variable 
            => (StringVariable) base.Variable;

        private string Value
        {
            get => Variable.Value;
            set => Variable.Value = value; 
        }

        public override void Fill(AVariable variable)
        {
            base.Fill(variable);
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