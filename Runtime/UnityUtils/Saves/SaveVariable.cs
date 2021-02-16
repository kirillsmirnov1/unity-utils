using UnityEngine;

namespace UnityUtils.Saves
{
    public abstract class SaveVariable : ScriptableObject
    {
        public abstract void ReadSave();
    }
}