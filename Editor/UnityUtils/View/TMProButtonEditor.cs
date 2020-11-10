using UnityEditor;
using UnityEngine;

namespace UnityUtils.View
{
    [CustomEditor(typeof(TMProButton))]
    public class TMProButtonEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("change interactable status"))
            {
                var t = (TMProButton) target;
                t.Interactable = !t.Interactable;
            }
            base.OnInspectorGUI();
        }
    }
}