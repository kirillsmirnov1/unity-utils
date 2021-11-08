using System;
using UnityEngine;
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
#pragma warning restore 0649
        
        public override string Uid => guid;
        public override Type Type => typeof(T);
        public override object RawValue => Value;
        public override bool IsPrimitive => typeof(T).IsPrimitive;

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
            InvokeOnChangeBase();
            OnChange?.Invoke(value);
        }

        public static implicit operator T(XVariable<T> v) => v.Value;
        public override string ToString() => Value.ToString();
    }
}