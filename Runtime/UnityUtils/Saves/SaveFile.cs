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

        private readonly Dictionary<string, int> _guidToVar = new Dictionary<string, int>();

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
                _guidToVar.Add(vars[i].Uid, i);
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
            
            var serializationPairs = JsonUtility.FromJson<SerializedVars>(str)
                .pairs;

            foreach (var serializationPair in serializationPairs)
            {
                ReadSaveToVariable(serializationPair);
            }
        }

        private void ReadSaveToVariable(SerializationPair serializationPair)
        {
            var variableIndex = _guidToVar[serializationPair.name];
            var variableRaw = vars[variableIndex];

            var serializedData = serializationPair.data;
            var data = variableRaw.IsPrimitive
                ? Convert.ChangeType(serializedData, variableRaw.Type) // IMPR no need to get it every time
                : JsonUtility.FromJson(serializedData, variableRaw.Type);
            
            variableRaw.Set(data);
        }

        private void WriteSave()
        {
            var serializedVars = new SerializedVars(vars.Length);
            for (int i = 0; i < vars.Length; i++)
            {
                var variable = vars[i];
                serializedVars.pairs[i].name = variable.Uid;
                serializedVars.pairs[i].data = variable.IsPrimitive
                    ? variable.ToString()
                    : JsonUtility.ToJson(variable.RawValue);
            }
            var serializedSave = JsonUtility.ToJson(serializedVars);
            SaveIO.WriteString(SaveFileName, serializedSave, _lockable, logSave);
        }
        
        [Serializable]
        public struct SerializedVars
        {
            public SerializedVars(int size)
            {
                pairs = new SerializationPair[size];
            }
            public SerializationPair[] pairs;
        }
        
        [Serializable]
        public struct SerializationPair
        {
            public string name;
            public string data;
        }
    }
}