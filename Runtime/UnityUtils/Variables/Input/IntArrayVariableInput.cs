using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.Extensions;

namespace UnityUtils.Variables.Input
{
    public class IntArrayVariableInput : VariableInput // TODO arrayVariableInput
    {
        [SerializeField] private IntArrayVariableInputEntry entryPrefab;
        [SerializeField] private RectTransform entryRoot;

        private List<IntArrayVariableInputEntry> _entries;

        public override Type VariableType => typeof(ArrayWrap<int>);

        protected new IntArrayVariable Variable
            => (IntArrayVariable) base.Variable;

        public override void Fill(AVariable variable, VariableInputProfile profile)
        {
            base.Fill(variable, profile);
            variableName.text = variable.name;
            ReGenerateElements();
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
            ReGenerateElements();
        }

        private void OnEntryChange(int index, int value)
        {
            // TODO 
        }

        private void ReGenerateElements()
        {
            ClearElements();
            for (int i = 0; i < Variable.Length; i++)
            {
                var entry = Instantiate(entryPrefab, entryRoot);
                entry.Fill(this, i, Variable[i]);
                _entries.Add(entry);
            }
            this.DelayAction(0f, () => LayoutRebuilder.ForceRebuildLayoutImmediate(entryRoot));
        }

        private void ClearElements()
        {
            for (int i = entryRoot.childCount - 1; i >= 0; i--)
            {
                Destroy(entryRoot.GetChild(i).gameObject);
            }
            _entries = new List<IntArrayVariableInputEntry>();
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