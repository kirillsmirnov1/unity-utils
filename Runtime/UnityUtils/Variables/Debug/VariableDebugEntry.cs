using UnityUtils.View;

namespace UnityUtils.Variables.Debug
{
    public abstract class VariableDebugEntry : ListViewEntry<AVariable>
    {
        protected AVariable Variable;
        public override void Fill(AVariable variable)
        {
            base.Fill(variable);
            Variable = variable;
        }
    }
}