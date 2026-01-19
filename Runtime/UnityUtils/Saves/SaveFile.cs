using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityUtils.SO;
using UnityUtils.Variables;

namespace UnityUtils.Saves
{
    [CreateAssetMenu(menuName = "Variables/SaveFile", fileName = "new SaveFile", order = 0)]
    public class SaveFile : InitiatedScriptableObject
    {
        [SerializeField] private string saveName;
        [SerializeField] private bool logSave;
        [SerializeField] private VariableReferencePair[] varRefs;
        
        private string SaveFileName => saveName;

        private readonly object _lockable = new object();

        public override void Init()
        {
            ReadSave();
            SubscribeToChanges();
        }

        public override void Stop()
        {
            UnsubscribeFromChanges();
            SetDefaultValues();
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
            SetDefaultValues();   
            SubscribeToChanges();
        }

        public void SetDefaultValues()
        {
            foreach (var varRef in varRefs)
            {
                if (varRef.defaultValue == null) continue;
                CloneValue(varRef.variable, varRef.defaultValue);
            }
        }

        private void CloneValue(AVariable to, AVariable from) 
            => to.Set(GetValueClone(from));

        // Serializing is the easiest way to create clean clone of data
        // As all vars references in SaveFile should be Serializable anyway
        private object GetValueClone(AVariable variableToClone) =>
            DeSerialized(
                variableToClone.IsPrimitive, 
                variableToClone.Type, 
                Serialized(variableToClone));
        
        private void ReadSave()
        {
            var str = SaveIO.ReadString(SaveFileName, _lockable, logSave);
            if (str.IsNull())
            {
                Debug.Log("No save found, writing defaults");
                SetDefaultValues();
                WriteSave();
                return;
            }

            var dataDict = SortByUid(str);
            PushSaveToVariables(dataDict);
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
                    PushSerializedDataToVariable(aVariable, dataDict[uid]);
                }
                else
                {
                    if (varRefs[i].defaultValue == null) continue;
                    CloneValue(aVariable, varRefs[i].defaultValue);
                }
            }
        }

        private void PushSerializedDataToVariable(AVariable variable, string dataString) 
            => variable.Set(
                DeSerialized(
                    variable.IsPrimitive, 
                    variable.Type, 
                    dataString));

        private object DeSerialized(bool isPrimitive, Type variableType, string dataString)
        {
            return isPrimitive 
                ? Convert.ChangeType(dataString, variableType)
                : JsonUtility.FromJson(dataString, variableType);
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