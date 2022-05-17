namespace UnityUtils.Variables.Input
{
    public class IntArrayVariableInput : ArrayVariableInput<int>
    {
        public void AddElement() 
            => Variable.Add(0);

        public override void RemoveElement(int index) 
            => Variable.RemoveAt(index);

        public override void OnEntryEdit(int index, int value) 
            => Variable[index] = value;
    }
}