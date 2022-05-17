using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils.Extensions;

namespace UnityUtils.Variables.Input
{
    public abstract class ArrayVariableInput<T> : VariableInput
    {
        public override Type VariableType => typeof(ListWrap<T>);
        
        [SerializeField] protected ArrayVariableInputEntry<T> entryPrefab;
        [SerializeField] protected RectTransform entryRoot;
        
        protected RectTransform Rect;
        protected List<ArrayVariableInputEntry<T>> Entries;

        public override void Fill(AVariable variable, VariableInputProfile profile)
        {
            base.Fill(variable, profile);
            Rect = GetComponent<RectTransform>();
        }
        
        protected void FillEntry(int i, T value) 
            => Entries[i].Fill(this, Profile, i, value);

        public abstract void OnEntryEdit(int index, T newValue); // IMPR implement here?

        public abstract void RemoveElement(int index); // IMPR implement here?
    }
}