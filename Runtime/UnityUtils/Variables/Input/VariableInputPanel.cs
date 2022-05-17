using System;
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
        [SerializeField] private VariableInput[] inputPrefabs;

        private Dictionary<Type, VariableInput> _inputPrefabs;

        protected override void OnValidate() { }

        private void Start()
        {
            InitPrefabs();
            SetEntries(variables.Select(x => x.variable).ToList());
        }

        private void InitPrefabs()
        {
            _inputPrefabs = new Dictionary<Type, VariableInput>();
            for (int i = 0; i < inputPrefabs.Length; i++)
            {
                var prefab = inputPrefabs[i];
                _inputPrefabs[prefab.VariableType] = prefab;
            }
        }

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

        private VariableInput PickPrefab(AVariable variable) 
            => _inputPrefabs.TryGetValue(variable.Type, out var prefab) 
                ? prefab 
                : null;
    }
}