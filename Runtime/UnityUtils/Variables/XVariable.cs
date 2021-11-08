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
    public abstract class XVariable<T> : AVariable
    {
        public event Action<T> OnChange;

#pragma warning disable 0649
        [SerializeField] protected T value;
        
        [Separator("Save")]
        [SerializeField] protected bool save;
        [SerializeField] [ConditionalField("save")] protected bool logSave;
        [SerializeField] [ConditionalField("save")] protected T defaultValue;
#pragma warning restore 0649

        private readonly object _lockable = new object();
        public override string SaveFileName => guid;
        public override Type Type => typeof(T);

        [SerializeField, HideInInspector] private string guid;

#if UNITY_EDITOR
        protected virtual void OnValidate()
        {
            CheckGuidSerialization();
            if (Application.isPlaying) OnDataChanged();
        }

        private void CheckGuidSerialization()
        {
            guid = AssetDatabase.GUIDFromAssetPath(AssetDatabase.GetAssetPath(this)).ToString();
            EditorUtility.SetDirty(this);
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

        public override void Set(object newValue) => Value = (T) newValue;

        private bool SameValue(T newValue) 
            => newValue == null && this.value == null 
               || newValue != null && newValue.Equals(this.value);

        protected void OnDataChanged()
        {
            OnChange?.Invoke(value);
            if (save) WriteSave();
        }

        public override void SetDefaultValue() => Value = defaultValue;

        public static implicit operator T(XVariable<T> v) => v.Value;
        public override string ToString() => Value.ToString();

        #region SaveVariable

        public override void Init() => ReadSave();

        protected virtual void ReadSave()
        {
            var str = SaveIO.ReadString(SaveFileName, _lockable, logSave);

            if (str.IsNull())
            {
                SetDefaultValue();
                WriteSave();
                return;
            }

            var data = IsPrimitive
                ? (T) Convert.ChangeType(str, typeof(T))
                : JsonUtility.FromJson<T>(str);

            Value = data;
        }

        protected void WriteSave()
            => SaveIO.WriteString(
                SaveFileName,
                IsPrimitive
                    ? Value.ToString()
                    : JsonUtility.ToJson(Value),
                _lockable,
                logSave);

        public override bool IsPrimitive => typeof(T).IsPrimitive;

        #endregion
    }
}