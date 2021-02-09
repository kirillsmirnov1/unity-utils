using UnityEngine;

namespace UnityUtils
{
    public class FrameRate : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private int frameRate = -1;
#pragma warning restore 0649

        private void Awake() => SetFrameRate();

        private void OnValidate() => SetFrameRate();

        private void SetFrameRate() => Application.targetFrameRate = frameRate;
    }
}