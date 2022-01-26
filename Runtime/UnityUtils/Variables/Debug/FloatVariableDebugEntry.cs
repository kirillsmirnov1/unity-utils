using TMPro;
using UnityEngine;

namespace UnityUtils.Variables.Debug
{
    public class FloatVariableDebugEntry : VariableDebugEntry
    {
        [SerializeField] private float iterationStep = 0.1f;
        [SerializeField] private int digitsAfterDot = 2;
        [SerializeField] private TMP_InputField text;

        private new FloatVariable Variable
            => (FloatVariable) base.Variable;

        private float Value
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

        private void SetValue(float val)
        {
            text.text = string.Format($"{{0:F{digitsAfterDot}}}", val);
        }

        public void OnEdit(string str)
        {
            Value = float.Parse(str);
        }

        public void OnPlus() => Value += iterationStep;
        public void OnMinus() => Value -= iterationStep;
    }
}