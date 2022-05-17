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
        private RectTransform _rect;

        public override Type VariableType => typeof(ArrayWrap<int>);

        protected new IntArrayVariable Variable
            => (IntArrayVariable) base.Variable;

        public override void Fill(AVariable variable, VariableInputProfile profile)
        {
            base.Fill(variable, profile);
            _rect = GetComponent<RectTransform>();
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
            if (newVal.Length != _entries.Count)
            {
                ReGenerateElements();
            }
            else
            {
                FillElements();
            }
        }

        private void FillElements()
        {
            for (int i = 0; i < Variable.Length; i++)
            {
                var value = Variable[i];
                _entries[i].Fill(this, i, value);
            }
        }

        private void OnEntryChange(int index, int value) 
            => _entries[index].Fill(this, index, value);

        private void ReGenerateElements()
        {
            ClearElements();
            for (int i = 0; i < Variable.Length; i++)
            {
                InstantiateEntry(i, Variable[i]);
            }
            ReBuildLayout();
        }

        private void InstantiateEntry(int i, int value)
        {
            var entry = Instantiate(entryPrefab, entryRoot);
            entry.Fill(this, i, value);
            _entries.Add(entry);
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
            Variable.Add(0);
            ReBuildLayout();
        }

        public void RemoveElement(int index)
        {
            // TODO 
        }

        public void OnEntryEdit(int index, int value) 
            => Variable[index] = value;

        private void ReBuildLayout() 
            => this.DelayAction(0f, () => LayoutRebuilder.ForceRebuildLayoutImmediate(_rect));
    }
}