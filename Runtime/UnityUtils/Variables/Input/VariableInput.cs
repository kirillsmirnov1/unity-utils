using UnityEngine;
using UnityEngine.UI;
using UnityUtils.View;

namespace UnityUtils.Variables.Input
{
    public abstract class VariableInput : ListViewEntry<AVariable>
    {
        [SerializeField] protected Text variableName;
        
        protected AVariable Variable;
        protected VariableInputProfile Profile;

        public sealed override void Fill(AVariable data)
        {
            base.Fill(data);
        }

        public virtual void Fill(AVariable variable, VariableInputProfile profile)
        {
            Fill(variable);
            variableName.text = variable.name;
            Variable = variable;
            Profile = profile;
        }
    }
}