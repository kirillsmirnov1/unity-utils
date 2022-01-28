using TMPro;
using UnityEngine;

namespace UnityUtils.Variables.Debug
{
    public class FloatVariableDebugEntry : VariableDebugEntry
    {
        [SerializeField] protected float iterationStep = 0.1f;
        [SerializeField] protected int digitsAfterDot = 2;
        [SerializeField] protected TMP_InputField text;

        protected new FloatVariable Variable
            => (FloatVariable) base.Variable;

        protected float Value
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

        protected virtual void OnDestroy()
        {
            Variable.OnChange -= SetValue;
        }

        protected virtual void SetValue(float val)
        {
            text.text = string.Format($"{{0:F{digitsAfterDot}}}", val);
        }

        public virtual void OnEdit(string str)
        {
            Value = float.Parse(str);
        }

        public virtual void OnPlus() => Value += iterationStep;
        public virtual void OnMinus() => Value -= iterationStep;
    }
}