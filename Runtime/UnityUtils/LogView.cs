using System.Text;
using TMPro;
using UnityEngine;
using UnityUtils.Attributes;

namespace UnityUtils
{
    public class LogView : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI logText;
        
        [Header("Settings")] 
        [SerializeField] private bool logStacktrace;
        [NamedArray(typeof(LogType))]
        [SerializeField] private Color[] logColors =
        {
            Color.red, 
            Color.magenta, 
            Color.yellow, 
            Color.black, 
            Color.red, 
        };
        
        private void Awake() => Application.logMessageReceived += Log;
        private void OnDestroy() => Application.logMessageReceived -= Log;

        private void Log(string condition, string stacktrace, LogType type)
        {
            var logMessage = new StringBuilder();
            logMessage.Append("<color=#");
            logMessage.Append(ColorUtility.ToHtmlStringRGB(logColors[(int) type]));
            logMessage.Append(">");
            logMessage.Append(condition);
            if (logStacktrace)
            {
                logMessage.Append("\n");
                logMessage.Append(stacktrace);
            }
            logMessage.Append("</color>");
            logMessage.Append("\n\n");

            logText.text += logMessage.ToString();
        }
    }
}
