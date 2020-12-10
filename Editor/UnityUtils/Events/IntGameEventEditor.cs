using UnityEditor;
using UnityEngine;
using UnityUtils.Events;

namespace Packages.Editor.UnityUtils.Events
{
    [CustomEditor(typeof(IntGameEvent))]
    public class IntGameEventEditor : UnityEditor.Editor
    {
        private string _input = "0";
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            GUILayout.BeginHorizontal();
            {
                _input = EditorGUILayout.TextField(_input);
                if (GUILayout.Button("Raise"))
                {
                    ((IntGameEvent)target).Raise(int.Parse(_input));
                }
            }
            GUILayout.EndHorizontal();
        }
    }
}