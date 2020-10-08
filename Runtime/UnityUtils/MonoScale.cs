using UnityEngine;

namespace UnityUtils
{
    public class MonoScale : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private float scale = 1;

        [Header("Axes to scale")]
        [SerializeField] private bool scaleX = true;
        [SerializeField] private bool scaleY = true;
        [SerializeField] private bool scaleZ = true;
#pragma warning restore 0649

        private void OnValidate()
        {
            var lastScale = transform.localScale;
            
            if (scaleX) lastScale.x = scale;
            if (scaleY) lastScale.y = scale;
            if (scaleZ) lastScale.z = scale;
            
            transform.localScale = lastScale;
        }
    }
}