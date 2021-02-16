using UnityEngine;

namespace UnityUtils.Saves
{
    public class InitSaveVariables : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private SaveVariable[] variables;
#pragma warning restore 0649

        private void Awake()
        {
            foreach (var variable in variables)
            {
                variable.ReadSave();
            }
        }
    }
}