using TMPro;
using UnityEngine;
using UnityUtils.View;

namespace UnityUtils.Variables.Debug
{
    public abstract class VariableDebugEntry : ListViewEntry<AVariable> // TODO show SO name 
    {
        [SerializeField] private TMP_Text variableName;
        
        protected AVariable Variable;
        public override void Fill(AVariable variable)
        {
            base.Fill(variable);
            variableName.text = variable.name;
            Variable = variable;
        }
    }
}