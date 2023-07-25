using System;
using UnityEngine;
using UnityEngine.UI;
using UnityUtils.View;

namespace UnityUtils.Variables.Input.XVarInput
{
    public abstract class VariableInput : ListViewEntry<AVariable>
    {
        public abstract Type VariableType { get; }
        
        [SerializeField] protected Text variableName;
        
        [SerializeField] protected AVariable Variable;
        [SerializeField] protected VariableInputProfile Profile;

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