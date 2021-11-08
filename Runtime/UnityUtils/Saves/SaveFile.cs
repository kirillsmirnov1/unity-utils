using System;
using System.Collections.Generic;
using UnityEngine;
using UnityUtils.Variables;

namespace UnityUtils.Saves
{
    [CreateAssetMenu(menuName = "Variables/SaveFile", fileName = "new SaveFile", order = 0)]
    public class SaveFile : InitiatedScriptableObject
    {
        [SerializeField] private bool logSave;
        [SerializeField] private AVariable[] vars;

        private readonly object _lockable = new object();
        private string SaveFileName => name;

        private readonly Dictionary<string, int> _uidToVar = new Dictionary<string, int>();

        public override void Init()
        {
            InitDictionary();
            ReadSave();
            SubscribeToChanges();
        }

        private void SubscribeToChanges() // IMPR other subscription modes 
        {
            foreach (var variable in vars)
            {
                variable.OnChangeBase += WriteSave;
            }
        }

        private void InitDictionary()
        {
            for (int i = 0; i < vars.Length; i++)
            {
                _uidToVar.Add(vars[i].Uid, i);
            }
        }

        private void ReadSave()
        {
            var str = SaveIO.ReadString(SaveFileName, _lockable, logSave);
            if (str.IsNull())
            {
                if(logSave) Debug.Log("No save found, writing current data");
                WriteSave();
                return;
            }

            var data = JsonUtility.FromJson<SaveFileData>(str);

            foreach (var dataPair in data.pairs)
            {
                PushSaveToVariable(dataPair);
            }
        }

        private void PushSaveToVariable(IdDataPair dataPair)
        {
            var variableIndex = _uidToVar[dataPair.uid];
            var variableRaw = vars[variableIndex];

            var serializedData = dataPair.data;
            var data = variableRaw.IsPrimitive
                ? Convert.ChangeType(serializedData, variableRaw.Type) // IMPR no need to get it every time
                : JsonUtility.FromJson(serializedData, variableRaw.Type);
            
            variableRaw.Set(data);
        }

        private void WriteSave()
        {
            var save = new SaveFileData(vars.Length);
            for (int i = 0; i < vars.Length; i++)
            {
                var variable = vars[i];
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
        }
    }
}