using UnityUtils.View;

namespace UnityUtils.Variables.Debug
{
    public abstract class VariableDebugEntry : ListViewEntry<AVariable> // TODO show SO name 
    {
        protected AVariable Variable;
        public override void Fill(AVariable variable)
        {
            base.Fill(variable);
            Variable = variable;
        }
    }
}