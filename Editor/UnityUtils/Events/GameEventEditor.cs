using UnityEditor;
using UnityEngine;

namespace UnityUtils.Events
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (GUILayout.Button("Raise"))
            {
                ((GameEvent)target).Raise();
            }
        }
    }
}