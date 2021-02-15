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

        private string SaveFileName => GetInstanceID().ToString();
        
        protected virtual void OnValidate()
        {
            OnChange?.Invoke(value);
            if (save) WriteSave();
        }

        private void Awake()
        {
            Debug.Log("In SO awake");
            if (save)
            {
                ReadSave(); // TODO check on first get attempt if inited 
            }
        }

        public T Value
        {
            get => value;
            set
            {
                if(value.Equals(this.value)) return;
                this.value = value;
                OnChange?.Invoke(this.value);
                if (save) WriteSave();
            }
        }

        public static implicit operator T(XVariable<T> v) => v.Value;
        public override string ToString() => Value.ToString();


        private void ReadSave()
        {
            var data = SaveIO.ReadObjectAsJsonString<T>(SaveFileName, _lockable, logSave);
            if (data.IsNull()) return;
            Value = data;
        }

        private void WriteSave() => SaveIO.WriteObjectAsJsonString(Value, SaveFileName, _lockable, logSave); // FIXME writes {}
    }
}