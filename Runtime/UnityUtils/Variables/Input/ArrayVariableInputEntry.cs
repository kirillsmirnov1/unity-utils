using UnityEngine;

namespace UnityUtils.Variables.Input
{
    public abstract class ArrayVariableInputEntry : MonoBehaviour
    {
        protected int Index;
        protected VariableInputProfile Profile;

        protected void Fill(VariableInputProfile profile, int i)
        {
            Profile = profile;
            Index = i;
        }
    }
}