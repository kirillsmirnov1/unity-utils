using TMPro;
using UnityEngine;

namespace UnityUtils.Variables.Debug
{
    public class StringVariableDebugEntry : VariableDebugEntry
    {
        [SerializeField] private TextMeshProUGUI text;

        private string Value
        {
            get => ((StringVariable) Variable).Value;
            set => ((StringVariable) Variable).Value = value; // TODO OnChange
        }
        
        public override void Fill(AVariable variable)
        {
            base.Fill(variable);
            text.text = Value; 
            // TODO subscribe OnChange
        }
        
        
    }
}