using System;
using MyBox;
using UnityEngine;
using UnityUtils.Saves;

namespace UnityUtils.Variables
{
    // [CreateAssetMenu(fileName = "New X Variable", menuName = "Variables/X Variable", order = 0)]
    public abstract class XVariable<T> : SaveVariable
    {
        public event Action<T> OnChange;

#pragma warning disable 0649
        [SerializeField] protected T value;
        
        [Header("")]
        [SerializeField] protected bool save;
        [SerializeField] [ConditionalField("save")] protected bool logSave;
        [SerializeField] [ConditionalField("save")] private XVariable<T> defaultValue;
#pragma warning restore 0649

        private readonly object _lockable = new object();
        private string SaveFileName => GetInstanceID().ToString();

        protected virtual void OnValidate()
        {
            if (!Application.isPlaying) return;
            OnDataChanged();
        }

        public T Value
        {
            get => value;
            set
            {
                if (value.Equals(this.value)) return;
                this.value = value;
                OnDataChanged();
            }
        }

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