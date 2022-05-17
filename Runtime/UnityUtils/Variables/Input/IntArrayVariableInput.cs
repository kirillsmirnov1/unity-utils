using System;
using UnityEngine;
using UnityUtils.Extensions;

namespace UnityUtils.Variables.Input
{
    public class IntArrayVariableInput : VariableInput // TODO arrayVariableInput
    {
        [SerializeField] private GameObject entryPrefab;
        [SerializeField] private RectTransform entryRoot;
        
        public override Type VariableType => typeof(ArrayWrap<int>);

        protected new IntArrayVariable Variable
            => (IntArrayVariable) base.Variable;

        public override void Fill(AVariable variable, VariableInputProfile profile)
        {
            base.Fill(variable, profile);
            variableName.text = variable.name;
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
            for (int i = 0; i < Variable.Length; i++)
            {
                // TODO use real entry prefab 
                Instantiate(entryPrefab, entryRoot);
            }
        }

        private void ClearElements()
        {
            for (int i = entryRoot.childCount - 1; i >= 0; i--)
            {
                Destroy(entryRoot.GetChild(i).gameObject);
            }
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