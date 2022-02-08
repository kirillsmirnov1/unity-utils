using System.Collections.Generic;
using UnityEngine;
using UnityUtils.View;

namespace UnityUtils.Variables.Input
{
    public class VariableInputPanel : ListView<AVariable>
    {
        [Header("Debug Panel")]
        [SerializeField] private List<AVariable> variables;
        
        [Header("Prefabs")] 
        [SerializeField] private GameObject stringVarDebugEntry;
        [SerializeField] private GameObject floatVarDebugEntry;
        // TODO prefabs

        protected override void OnValidate() { }

        private void Start() => SetEntries(variables);

        protected override void CheckConsistency(List<AVariable> data)
        {
            // Gonna leave it empty for now
        }

        protected override void FillData(List<AVariable> data)
        {
            for (int i = 0; i < data.Count; i++)
            {
                var variable = data[i];
                var prefab = PickPrefab(variable);
                if (prefab == null)
                {
                    UnityEngine.Debug.LogWarning($"No prefab for {variable}");
                }
                else
                {
                    var entry = Instantiate(prefab, scrollContent).GetComponent<VariableInput>();
                    entries.Add(entry);
                    entry.Fill(variable);
                }
            }
        }

        private GameObject PickPrefab(AVariable variable) =>
            variable switch
            {
                StringVariable _ => stringVarDebugEntry,
                FloatVariable _ => floatVarDebugEntry,
                _ => null
            };
    }
}