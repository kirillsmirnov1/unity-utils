using UnityEngine;
using UnityEngine.Audio;
using UnityUtils.Variables;

namespace UnityUtils.Audio
{
    public class VolumeManager : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private BoolVariable volumeOn;
        [SerializeField] private AudioMixer audioGroup;
#pragma warning restore 0649

        private void Start() => SetVolume(volumeOn);
        private void Awake() => volumeOn.OnChange += SetVolume;
        private void OnDestroy() => volumeOn.OnChange -= SetVolume;
        private void SetVolume(bool volume) => audioGroup.SetFloat("Volume", volume ? 0 : -80);
    }
}