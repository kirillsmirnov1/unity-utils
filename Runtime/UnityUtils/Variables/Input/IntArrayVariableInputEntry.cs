using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.Variables.Input
{
    public class IntArrayVariableInputEntry : ArrayVariableInputEntry<int>
    {
        [SerializeField] private InputField input;

        protected override void UpdateValueDisplay(int newValue) 
            => input.text = newValue.ToString();

        public void OnEdit(string str) 
            => Parent.OnEntryEdit(Index, int.Parse(str));

        public void OnPlusPressed() 
            => ChangeValue(Value + Profile.intIterationStep);

        public void OnMinusPressed() 
            => ChangeValue(Value - Profile.intIterationStep);

        public void OnXPressed() 
            => Parent.RemoveElement(Index);

        private void ChangeValue(int newValue) 
            => Parent.OnEntryEdit(Index, newValue);
    }
}