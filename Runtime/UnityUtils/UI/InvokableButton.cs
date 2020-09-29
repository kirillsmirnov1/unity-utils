using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.UI
{
    public class InvokableButton : MonoBehaviour
    {
        private Button _button;

        private void Awake ()
        {
            if (_button == null)
                _button = GetComponent<Button>();
        }
 
        public void Invoke()
        {
            if (_button != null)
            {
                _button.onClick?.Invoke();
            }
        }
    }
}