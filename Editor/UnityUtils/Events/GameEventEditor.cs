using UnityEditor;
using UnityEngine;
using UnityUtils.Events;

namespace Packages.Editor.UnityUtils.Events
{
    [CustomEditor(typeof(GameEvent))]
    public class GameEventEditor : UnityEditor.Editor
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