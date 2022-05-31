using TMPro;
using UnityEngine;

namespace UnityUtils.Variables.Display
{
    public abstract class XVariableDisplay <T> : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] protected XVariable<T> variable;
        
        [Header("Formatting")]
        [SerializeField] protected string prefix;
        [SerializeField] protected string format = "{0}";
        [SerializeField] protected string postfix;
        
        [Header("Text fields")]
        [SerializeField] protected TextMeshProUGUI valueText;
        [SerializeField] protected TextMeshProUGUI nameText;
#pragma warning restore 0649

        private void Start()
        {
            nameText.text = variable.name;
        }

        private void OnEnable()
        {
            SetText(variable);
            variable.OnChange += OnChange;
        }

        private void OnDisable()
        {
            variable.OnChange -= OnChange;   
        }

        protected virtual void SetText(T value) => valueText.text = $"{prefix}{string.Format(format, value)}{postfix}";

        protected virtual void OnChange(T value) => SetText(value);
    }
}