using UnityUtils.Extensions;

namespace UnityUtils.Variables.Input
{
    public class IntArrayVariableInput : ArrayVariableInput<int>
    {
        public override void Fill(AVariable variable, VariableInputProfile profile)
        {
            base.Fill(variable, profile);
            
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

        public void AddElement() 
            => Variable.Add(0);

        public override void RemoveElement(int index) 
            => Variable.RemoveAt(index);

        public override void OnEntryEdit(int index, int value) 
            => Variable[index] = value;
    }
}