using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.Variables.Input
{
    public class BoolVariableInput : VariableInput
    {
        [SerializeField] private Toggle toggle;

        private new BoolVariable Variable
            => (BoolVariable) base.Variable;

        private bool Value
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

        private void SetValue(bool newValue)
        {
            if(newValue == toggle.isOn) return;
            toggle.isOn = newValue;
        }

        public void OnToggle(bool isOn) => Value = isOn;
    }
}