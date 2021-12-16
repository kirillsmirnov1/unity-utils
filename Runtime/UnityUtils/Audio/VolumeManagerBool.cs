using UnityEngine;
using UnityEngine.Audio;
using UnityUtils.Variables;

namespace UnityUtils.Audio
{
    public class VolumeManagerBool : MonoBehaviour
    {
        [SerializeField] private BoolVariable volumeOn;
        [SerializeField] private AudioMixer audioGroup;
        [SerializeField] private string volumeParamName = "Volume";

        private void OnEnable() => SetVolume(volumeOn);
        private void Awake() => volumeOn.OnChange += SetVolume;
        private void OnDestroy() => volumeOn.OnChange -= SetVolume;
        private void SetVolume(bool volume) => audioGroup.SetFloat(volumeParamName, volume ? 0 : -80);
    }
}