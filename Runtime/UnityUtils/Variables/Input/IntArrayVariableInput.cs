using System;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.Extensions;

namespace UnityUtils.Variables.Input
{
    public class IntArrayVariableInput : VariableInput // TODO arrayVariableInput
    {
        [SerializeField] private Text arrayName;
        [SerializeField] private GameObject entryPrefab;
        
        public override Type VariableType => typeof(ArrayWrap<int>);

        protected new IntArrayVariable Variable
            => (IntArrayVariable) base.Variable;

        public override void Fill(AVariable variable, VariableInputProfile profile)
        {
            base.Fill(variable, profile);
            arrayName.text = variable.name;
            GenerateElements();
            Variable.OnChange += OnVariableChange;
            Variable.OnEntryChange += OnEntryChange;
        }

        private void OnDestroy()
        {
            Variable.OnChange -= OnVariableChange;
            Variable.OnEntryChange -= OnEntryChange;
        }

        private void OnVariableChange(ArrayWrap<int> newVal)
        {
            GenerateElements();
        }

        private void OnEntryChange(int index, int value)
        {
            // TODO 
        }

        private void GenerateElements()
        {
            ClearElements();
            // TODO 
        }

        private void ClearElements()
        {
            // TODO 
        }

        public void AddElement()
        {
            // TODO 
        }

        public void RemoveElement(int index)
        {
            // TODO 
        }

        public void OnEntryEdit(int index, int value) 
            => Variable[index] = value;
    }
}