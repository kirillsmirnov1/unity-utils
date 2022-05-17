using System;
using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.Variables.Input
{
    public class IntVariableInput : VariableInput
    {
        public override Type VariableType => typeof(int);
        
        [SerializeField] private protected InputField text;

        protected int IterationStep = 1;

        protected new IntVariable Variable
            => (IntVariable) base.Variable;

        protected int Value
        {
            get => Variable.Value;
            set => Variable.Value = value;
        }

        public override void Fill(AVariable variable, VariableInputProfile profile)
        {
            base.Fill(variable, profile);
            IterationStep = profile.intIterationStep;
            SetValue(Value);
            Variable.OnChange += SetValue;
        }

        private void OnDestroy()
        {
            Variable.OnChange -= SetValue;
        }

        private void SetValue(int value)
        {
            text.text = value.ToString();
        }

        public virtual void OnEdit(string str)
        {
            Value = int.Parse(str);
        }

        public virtual void OnPlus() => Value += IterationStep;
        public virtual void OnMinus() => Value -= IterationStep;
    }
}
