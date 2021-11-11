using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityUtils.Variables;

namespace UnityUtils.Saves
{
    [CreateAssetMenu(menuName = "Variables/SaveFile", fileName = "new SaveFile", order = 0)]
    public class SaveFile : InitiatedScriptableObject
    {
        [SerializeField] private bool logSave;
        [SerializeField] private VariableReferencePair[] varRefs;

        private readonly object _lockable = new object();
        private string SaveFileName => name;

        private readonly Dictionary<string, VariableReference> _uidToVar = new Dictionary<string, VariableReference>();

        public override void Init()
        {
            InitDictionary();
            ReadSave();
            SubscribeToChanges();
        }

        private void SubscribeToChanges() // IMPR other subscription modes 
        {
            foreach (var varRef in varRefs)
            {
                varRef.variable.OnChangeBase += WriteSave;
            }
        }
        
        private void UnsubscribeFromChanges() // IMPR other subscription modes 
        {
            foreach (var varRef in varRefs)
            {
                varRef.variable.OnChangeBase -= WriteSave;
            }
        }

        public void ResetToDefaults()
        {
            UnsubscribeFromChanges();
            foreach (var varRef in varRefs)
            {
                if(varRef.defaultValue == null) continue;
                varRef.variable.Set(varRef.defaultValue.RawValue);
            }   
            SubscribeToChanges();
        }

        private void InitDictionary()
        {
            for (int i = 0; i < varRefs.Length; i++)
            {
                var variable = varRefs[i].variable;
                _uidToVar.Add(variable.Uid, new VariableReference {Variable = variable, Type = variable.Type});
            }
        }

        private void ReadSave()
        {
            var str = SaveIO.ReadString(SaveFileName, _lockable, logSave);
            if (str.IsNull())
            {
                Debug.Log("No save found, writing defaults");
                PushDefaultsToVariables();
                WriteSave();
                return;
            }

            var dataDict = SortByUid(str);
            PushSaveToVariables(dataDict);
        }

        private void PushDefaultsToVariables()
        {
            foreach (var varRef in varRefs)
            {
                if (varRef.defaultValue != null)
                {
                    varRef.variable.Set(varRef.defaultValue.RawValue);
                }
            }
        }

        private static Dictionary<string, string> SortByUid(string saveFileData) 
            => JsonUtility.FromJson<SaveFileData>(saveFileData)
                .pairs
                .ToDictionary(pair => pair.uid, pair => pair.data);

        private void PushSaveToVariables(Dictionary<string, string> dataDict)
        {
            for (int i = 0; i < varRefs.Length; i++)
            {
                var aVariable = varRefs[i].variable;
                var uid = aVariable.Uid;
                if (dataDict.ContainsKey(uid))
                {
                    PushSaveToVariable(aVariable, dataDict[uid]);
                }
                else
                {
                    if (varRefs[i].defaultValue == null) continue;
                    aVariable.Set(varRefs[i].defaultValue.RawValue);
                }
            }
        }

        private void PushSaveToVariable(AVariable variable, string dataString)
        {
            var variableRef = _uidToVar[variable.Uid];
            var variableType = variableRef.Type;
            var aVariable = variableRef.Variable;
            
            var data = aVariable.IsPrimitive
                ? Convert.ChangeType(dataString, variableType)
                : JsonUtility.FromJson(dataString, variableType);
            
            aVariable.Set(data);
        }

        private void WriteSave()
        {
            var save = new SaveFileData(varRefs.Length);
            for (int i = 0; i < varRefs.Length; i++)
            {
                var variable = varRefs[i].variable;
                save.pairs[i] = new IdDataPair(variable.Uid, Serialized(variable));
            }
            var serializedSave = JsonUtility.ToJson(save);
            SaveIO.WriteString(SaveFileName, serializedSave, _lockable, logSave);
        }

        private static string Serialized(AVariable variable)
        {
            return variable.IsPrimitive
                ? variable.ToString()
                : JsonUtility.ToJson(variable.RawValue);
        }

        [Serializable]
        public struct SaveFileData
        {
            public IdDataPair[] pairs;
            
            public SaveFileData(int size) 
                => pairs = new IdDataPair[size];
        }
        
        [Serializable]
        public struct IdDataPair
        {
            public IdDataPair(string id, string data) 
                => (uid, this.data) = (id, data);
            
            public string uid;
            public string data;

            public override string ToString() => $"uid: {uid}, data: {data}";
        }

        [Serializable]
        public struct VariableReferencePair
        {
            public AVariable variable;
            public AVariable defaultValue;
        }

        private struct VariableReference
        {
            public AVariable Variable;
            public Type Type;
        }
    }
}