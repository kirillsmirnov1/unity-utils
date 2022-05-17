using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.Extensions;

namespace UnityUtils.Variables.Input
{
    public abstract class ArrayVariableInput<T> : VariableInput
    {
        protected new XArrayVariable<T> Variable
            => (XArrayVariable<T>) base.Variable;
        
        public override Type VariableType => typeof(ListWrap<T>);
        
        [SerializeField] protected ArrayVariableInputEntry<T> entryPrefab;
        [SerializeField] protected RectTransform entryRoot;
        
        protected RectTransform Rect;
        protected List<ArrayVariableInputEntry<T>> Entries;

        public override void Fill(AVariable variable, VariableInputProfile profile)
        {
            base.Fill(variable, profile);
            Rect = GetComponent<RectTransform>();
            ReGenerateElements();
            
            Variable.OnChange += OnVariableChange;
            Variable.OnEntryChange += FillEntry;
        }
        
        protected virtual void OnDestroy()
        {
            Variable.OnChange -= OnVariableChange;
            Variable.OnEntryChange -= FillEntry;
        }
        
        private void OnVariableChange(ListWrap<T> newVal)
        {
            if (newVal.Length != Entries.Count)
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
        
        protected void ReGenerateElements()
        {
            ClearElements();
            for (int i = 0; i < Variable.Length; i++)
            {
                InstantiateEntry(i, Variable[i]);
            }
            ReBuildLayout();
        }

        private void ClearElements()
        {
            for (int i = entryRoot.childCount - 1; i >= 0; i--)
            {
                Destroy(entryRoot.GetChild(i).gameObject);
            }
            Entries = new List<ArrayVariableInputEntry<T>>();
        }

        private void InstantiateEntry(int i, T value)
        {
            var entry = Instantiate(entryPrefab, entryRoot);
            Entries.Add(entry);
            FillEntry(i, value);
        }
        
        private void ReBuildLayout() 
            => this.DelayAction(0f, () => LayoutRebuilder.ForceRebuildLayoutImmediate(Rect));
        
        protected void FillEntry(int i, T value) 
            => Entries[i].Fill(this, Profile, i, value);

        public abstract void OnEntryEdit(int index, T newValue); // IMPR implement here?

        public abstract void RemoveElement(int index); // IMPR implement here?
    }
}