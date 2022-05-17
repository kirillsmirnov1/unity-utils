using System.Collections.Generic;
using UnityEngine.UI;
using UnityUtils.Extensions;

namespace UnityUtils.Variables.Input
{
    public class IntArrayVariableInput : ArrayVariableInput<int>
    {
        protected new IntArrayVariable Variable
            => (IntArrayVariable) base.Variable;

        public override void Fill(AVariable variable, VariableInputProfile profile)
        {
            base.Fill(variable, profile);

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
            Entries.Add(entry);
            FillEntry(i, value);
        }

        private void ClearElements()
        {
            for (int i = entryRoot.childCount - 1; i >= 0; i--)
            {
                Destroy(entryRoot.GetChild(i).gameObject);
            }
            Entries = new List<ArrayVariableInputEntry<int>>();
        }

        public void AddElement() 
            => Variable.Add(0);

        public override void RemoveElement(int index) 
            => Variable.RemoveAt(index);

        public override void OnEntryEdit(int index, int value) 
            => Variable[index] = value;

        private void ReBuildLayout() 
            => this.DelayAction(0f, () => LayoutRebuilder.ForceRebuildLayoutImmediate(Rect));
    }
}