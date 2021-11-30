using UnityEditor;
using UnityEngine;

namespace UnityUtils.Events
{
    [CustomEditor(typeof(StringGameEvent))]
    public class StringGameEventEditor : Editor
    {
        private string _input = "";
        
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            
            GUILayout.BeginHorizontal();
            {
                _input = EditorGUILayout.TextField(_input);
                if (GUILayout.Button("Raise"))
                {
                    ((StringGameEvent)target).Raise(_input);
                }
            }
            GUILayout.EndHorizontal();
        }
    }
}