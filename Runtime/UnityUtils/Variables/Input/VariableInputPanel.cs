using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityUtils.View;

namespace UnityUtils.Variables.Input
{
    public class VariableInputPanel : ListView<AVariable>
    {
        [Header("Settings")]
        [SerializeField] private VariableInputProfile profile;
        
        [Header("Debug Panel")]
        [SerializeField] private List<VariableWithProfile> variables;
        
        [Header("Prefabs")] 
        [SerializeField] private GameObject stringVarInput;
        [SerializeField] private GameObject floatVarInput;
        [SerializeField] private GameObject boolVarInput;
        [SerializeField] private GameObject intVarInput;

        // TODO prefabs

        protected override void OnValidate() { }

        private void Start() => SetEntries(variables.Select(x => x.variable).ToList());

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
                    var profileOverride = variables[i].profileOverride; 
                    entry.Fill(variable, profileOverride == null ? profile : profileOverride);
                }
            }
        }

        private GameObject PickPrefab(AVariable variable) =>
            variable switch
            {
                StringVariable _ => stringVarInput,
                FloatVariable _ => floatVarInput,
                BoolVariable _ => boolVarInput,
                IntVariable _ => intVarInput,
                _ => null
            };
    }
}