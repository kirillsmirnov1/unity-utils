using UnityEngine;
using UnityEngine.UI;
using UnityUtils.Variables;

namespace UnityUtils.View
{
    public class VolumeToggle : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private BoolVariable soundIsOn;
        [SerializeField] private Toggle toggle;
        [SerializeField] private Image background;
#pragma warning restore 0649

        private void Awake()
        {
            toggle.onValueChanged.AddListener(OnToggleValueChange);
            soundIsOn.OnChange += SetToggleValue;
        }

        private void OnDestroy()
        {
            toggle.onValueChanged.RemoveListener(OnToggleValueChange);
            soundIsOn.OnChange -= SetToggleValue;
        }

        private void Start() => SetToggleValue(soundIsOn);

        private void SetToggleValue(bool newValue)
        {
            if(toggle.isOn == newValue) return;
            background.enabled = !newValue;
            toggle.isOn = newValue;
        }

        private void OnToggleValueChange(bool newValue)
        {
            if(newValue == soundIsOn) return;
            background.enabled = !newValue;
            soundIsOn.Value = newValue;
        }
    }
}