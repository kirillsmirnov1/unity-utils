using UnityEngine;
using UnityUtils.Variables;

namespace UnityUtils.View
{
    [RequireComponent(typeof(CanvasGroup))]
    public class FlipCanvasGroupVisibility : MonoBehaviour
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private BoolVariable flag;

        private void Awake()
        {
            SetAlpha(flag);
            flag.OnChange += SetAlpha;
        }

        private void OnDestroy()
        {
            flag.OnChange -= SetAlpha;
        }

        private void SetAlpha(bool show)
        {
            canvasGroup.alpha = show ? 1f : 0f;
        }
    }
}