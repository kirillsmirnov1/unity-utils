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

        public override Type VariableType => typeof(ListWrap<int>);

        protected new IntArrayVariable Variable
            => (IntArrayVariable) base.Variable;

        public override void Fill(AVariable variable, VariableInputProfile profile)
        {
            base.Fill(variable, profile);
            _rect = GetComponent<RectTransform>();
            variableName.text = variable.name;
            ReGenerateElements();
            Variable.OnChange += OnVariableChange;
            Variable.OnEntryChange += FillEntry;
        }

        private void OnDestroy()
        {
            Variable.OnChange -= OnVariableChange;
            Variable.OnEntryChange -= FillEntry;
        }

        private void OnVariableChange(ListWrap<int> newVal)
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
                FillEntry(i, value);
            }
        }

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
            _entries.Add(entry);
            FillEntry(i, value);
        }

        private void FillEntry(int i, int value) 
            => _entries[i].Fill(this, Profile, i, value);

        private void ClearElements()
        {
            for (int i = entryRoot.childCount - 1; i >= 0; i--)
            {
                Destroy(entryRoot.GetChild(i).gameObject);
            }
            _entries = new List<IntArrayVariableInputEntry>();
        }

        public void AddElement() 
            => Variable.Add(0);

        public void RemoveElement(int index) 
            => Variable.RemoveAt(index);

        public void OnEntryEdit(int index, int value) 
            => Variable[index] = value;

        private void ReBuildLayout() 
            => this.DelayAction(0f, () => LayoutRebuilder.ForceRebuildLayoutImmediate(_rect));
    }
}