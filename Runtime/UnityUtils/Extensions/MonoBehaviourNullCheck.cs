using System;
using System.Reflection;
using UnityEngine;

namespace UnityUtils
{
    public static class MonoBehaviourNullCheck
    {
        /// <summary>
        /// Checks non-static public and serialized fields of object. Prints warnings in log on null fields.
        /// <para>Example usage:</para>
        /// <para>OnValidate() => CheckNullFields(this)</para>
        /// </summary>
        private static bool CheckNullFieldsImpl(this UnityEngine.Object obj)
        {
            var noNullFields = true;
            var type = obj.GetType();
            foreach (var field in type.GetRuntimeFields())
            {
                if (!field.IsStatic && (field.IsPublic || Attribute.IsDefined(field, typeof(SerializeField))))
                {
                    var val = field.GetValue(obj);
                    if (val.IsNull())
                    {
                        Debug.LogWarning($"{obj.GetType().Name}: {field.Name} is null");
                        noNullFields = false;
                    }
                }
            }
            return noNullFields;
        }

        public static bool CheckNullFields(this MonoBehaviour obj) => CheckNullFieldsImpl(obj);
        public static bool CheckNullFields(this ScriptableObject obj) => CheckNullFieldsImpl(obj);

        public static bool CheckNullFieldsIfNotPrefab(this MonoBehaviour obj)
            => obj.gameObject.InPrefabScene() || CheckNullFields(obj);

        public static bool IsNull(this object obj) => obj == null || obj.Equals(null);
    }
}