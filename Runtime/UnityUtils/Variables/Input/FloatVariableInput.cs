using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.Variables.Input
{
    public class FloatVariableInput : VariableInput
    {
        public override Type VariableType => typeof(float);
        
        [SerializeField] protected InputField text;
        
        protected int DigitsAfterDot = 2;
        protected float IterationStep = 0.1f;

        protected new FloatVariable Variable
            => (FloatVariable) base.Variable;

        protected float Value
        {
            get => Variable.Value;
            set => Variable.Value = value;
        }

        public override void Fill(AVariable variable, VariableInputProfile profile)
        {
            base.Fill(variable, profile);
            DigitsAfterDot = profile.digitsAfterDot;
            IterationStep = profile.floatIterationStep;
            SetValue(Value);
            Variable.OnChange += SetValue;
        }

        protected virtual void OnDestroy()
        {
            Variable.OnChange -= SetValue;
        }

        protected virtual void SetValue(float val)
        {
            text.text = string.Format($"{{0:F{DigitsAfterDot}}}", val);
        }

        public virtual void OnEdit(string str)
        {
            Value = float.Parse(str);
        }

        public virtual void OnPlus() => Value += IterationStep;
        public virtual void OnMinus() => Value -= IterationStep;
    }
}