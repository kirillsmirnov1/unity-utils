using UnityEngine;
using UnityEngine.UI;
using UnityUtils.Variables;

namespace UnityUtils.View
{
    public class BoolVariableToggle : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private BoolVariable variable;
        [SerializeField] private Toggle toggle;
        [SerializeField] private Image background;
#pragma warning restore 0649

        private void Awake()
        {
            toggle.onValueChanged.AddListener(OnToggleValueChange);
            variable.OnChange += SetToggleValue;
        }

        private void OnDestroy()
        {
            toggle.onValueChanged.RemoveListener(OnToggleValueChange);
            variable.OnChange -= SetToggleValue;
        }

        private void Start() => SetToggleValue(variable);

        private void SetToggleValue(bool newValue)
        {
            if(toggle.isOn == newValue) return;
            background.enabled = !newValue;
            toggle.isOn = newValue;
        }

        private void OnToggleValueChange(bool newValue)
        {
            if(newValue == variable) return;
            background.enabled = !newValue;
            variable.Value = newValue;
        }
    }
}