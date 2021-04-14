using System;
using UnityUtils.Attributes;
using UnityEngine;
using UnityUtils.Saves;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace UnityUtils.Variables
{
    // [CreateAssetMenu(fileName = "New X Variable", menuName = "Variables/X Variable", order = 0)]
    public abstract class XVariable<T> : SaveVariable
    {
        public event Action<T> OnChange;

#pragma warning disable 0649
        [SerializeField] protected T value;
        
        [Separator("Save")]
        [SerializeField] protected bool save;
        [SerializeField] [ConditionalField("save")] protected bool logSave;
        [SerializeField] [ConditionalField("save")] protected XVariable<T> defaultValue;
#pragma warning restore 0649

        private readonly object _lockable = new object();
        private string SaveFileName => guid;

        [SerializeField, HideInInspector] private string guid;

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            guid = AssetDatabase.GUIDFromAssetPath(AssetDatabase.GetAssetPath(this)).ToString();
            if (Application.isPlaying) OnDataChanged();
        }
#endif

        public T Value
        {
            get => value;
            set
            {
                if (SameValue(value)) return;
                this.value = value;
                OnDataChanged();
            }
        }

        private bool SameValue(T newValue) 
            => newValue == null && this.value == null 
               || newValue != null && newValue.Equals(this.value);

        protected void OnDataChanged()
        {
            OnChange?.Invoke(value);
            if (save) WriteSave();
        }

        public static implicit operator T(XVariable<T> v) => v.Value;
        public override string ToString() => Value.ToString();

        #region SaveVariable

        public override void ReadSave()
        {
            var str = SaveIO.ReadString(SaveFileName, _lockable, logSave);

            if (str.IsNull())
            {
                value = defaultValue;
                WriteSave();
                return;
            }

            var data = typeof(T).IsPrimitive
                ? (T) Convert.ChangeType(str, typeof(T))
                : JsonUtility.FromJson<T>(str);

            Value = data;
        }

        protected void WriteSave()
            => SaveIO.WriteString(
                SaveFileName,
                typeof(T).IsPrimitive
                    ? Value.ToString()
                    : JsonUtility.ToJson(Value),
                _lockable,
                logSave);

        #endregion
    }
}