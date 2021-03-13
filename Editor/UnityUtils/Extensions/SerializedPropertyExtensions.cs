using System;
using UnityEditor;

namespace Packages.Editor.UnityUtils.Extensions
{
    public static class SerializedPropertyExtensions
    {
        /// <summary>
        /// Get string representation of serialized property
        /// </summary>
        public static string AsStringValue(this SerializedProperty property)
        {
            switch (property.propertyType)
            {
                case SerializedPropertyType.String:
                    return property.stringValue;

                case SerializedPropertyType.Character:
                case SerializedPropertyType.Integer:
                    if (property.type == "char") return Convert.ToChar(property.intValue).ToString();
                    return property.intValue.ToString();

                case SerializedPropertyType.ObjectReference:
                    return property.objectReferenceValue != null ? property.objectReferenceValue.ToString() : "null";

                case SerializedPropertyType.Boolean:
                    return property.boolValue.ToString();

                case SerializedPropertyType.Enum:
                    return property.enumNames[property.enumValueIndex];

                default:
                    return string.Empty;
            }
        }
    }
}