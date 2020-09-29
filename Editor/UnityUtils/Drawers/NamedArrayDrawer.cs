using UnityEditor;
using UnityEngine;
using UnityUtils.Attributes;

namespace UnityUtils.Drawers
{
    [CustomPropertyDrawer(typeof(NamedArrayAttribute))]
    public class NamedArrayDrawer : PropertyDrawer {
        public override float GetPropertyHeight(SerializedProperty property, GUIContent label) {
            // Properly configure height for expanded contents.
            return EditorGUI.GetPropertyHeight(property, label, property.isExpanded);
        }
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label) {
            // Replace label with enum name if possible.
            try {
                var config = attribute as NamedArrayAttribute;
                var enumNames = System.Enum.GetNames(config.TargetEnum);
                var pos = int.Parse(property.propertyPath.Split('[', ']')[1]);
                var enumLabel = enumNames.GetValue(pos) as string;
                // Make names nicer to read (but won't exactly match enum definition).
                enumLabel = ObjectNames.NicifyVariableName(enumLabel.ToLower());
                label = new GUIContent(enumLabel);
            } catch {
                // keep default label
            }
            EditorGUI.PropertyField(position, property, label, property.isExpanded);
        }
    }
}