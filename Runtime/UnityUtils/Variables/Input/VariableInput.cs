using UnityEngine;
using UnityEngine.UI;
using UnityUtils.View;

namespace UnityUtils.Variables.Input
{
    public abstract class VariableInput : ListViewEntry<AVariable>
    {
        [SerializeField] protected Text variableName;
        
        protected AVariable Variable;
        public override void Fill(AVariable variable)
        {
            base.Fill(variable);
            variableName.text = variable.name;
            Variable = variable;
        }
    }
}