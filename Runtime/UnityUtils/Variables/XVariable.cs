using System;
using UnityEngine;
using UnityUtils.Saves;

namespace UnityUtils.Variables
{
    // [CreateAssetMenu(fileName = "New X Variable", menuName = "Variables/X Variable", order = 0)]
    public abstract class XVariable<T> : ScriptableObject
    {
        public event Action<T> OnChange;
        
#pragma warning disable 0649
        [SerializeField] private T value;
        
        [Header("Save")]
        [SerializeField] protected bool save;
        [SerializeField] protected bool logSave;
#pragma warning restore 0649
        
        private readonly object _lockable = new object();
        [NonSerialized] private bool _initiated;

        private string SaveFileName => GetInstanceID().ToString();
        
        protected virtual void OnValidate()
        {
            if(!Application.isPlaying) return;
            OnDataChanged();
        }

        public T Value
        {
            get
            {
                if (!_initiated)
                {
                    ReadSave();
                    _initiated = true;
                }
                return value;
            }
            set
            {
                if(value.Equals(this.value)) return;
                this.value = value;
                OnDataChanged();
            }
        }

        private void OnDataChanged()
        {
            OnChange?.Invoke(value);
            if (save) WriteSave();
        }

        public static implicit operator T(XVariable<T> v) => v.Value;
        public override string ToString() => Value.ToString();


        private void ReadSave()
        {
            var str = SaveIO.ReadString(SaveFileName, _lockable, logSave);
            if (str.IsNull())
            {
                WriteSave();
                return;
            }
            
            var data = typeof(T).IsPrimitive 
                ? (T)Convert.ChangeType(str, typeof(T)) 
                : JsonUtility.FromJson<T>(str);
            
            Value = data;
        }

        private void WriteSave() 
            => SaveIO.WriteString(
                SaveFileName, 
                typeof(T).IsPrimitive 
                    ? Value.ToString() 
                    : JsonUtility.ToJson(Value), 
                _lockable, 
                logSave);
    }

}