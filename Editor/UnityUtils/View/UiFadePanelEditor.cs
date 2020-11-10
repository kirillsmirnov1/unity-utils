using UnityEditor;
using UnityEngine;
using UnityUtils.VisualEffects;

namespace UnityUtils.View
{
    [CustomEditor(typeof(UiFadePanel))]
    public class UiFadePanelEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            var panel = (UiFadePanel) target;
            
            if(GUILayout.Button("Show")) panel.Show();
            if(GUILayout.Button("Hide")) panel.Hide();
        }
    }
}