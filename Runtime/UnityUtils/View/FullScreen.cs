using UnityEngine;
using UnityUtils.Variables;

namespace UnityUtils.View
{
    public class FullScreen : MonoBehaviour
    {
        [SerializeField] private BoolVariable fullScreenToggle;

        private void Awake()
        {
            SetFullScreenMode(fullScreenToggle);
            if (fullScreenToggle != null) fullScreenToggle.OnChange += SetFullScreenMode;
        }

        private void OnDestroy()
        {
            if (fullScreenToggle != null) fullScreenToggle.OnChange -= SetFullScreenMode;
        }

        public void SetFullScreenMode(bool fullScreenIsOn)
        {
            Screen.fullScreen = fullScreenIsOn;
            if (fullScreenIsOn)
            {
                var currRes = Screen.currentResolution;
                Screen.SetResolution(currRes.width, currRes.height, true);
            }
        }
    }
}
