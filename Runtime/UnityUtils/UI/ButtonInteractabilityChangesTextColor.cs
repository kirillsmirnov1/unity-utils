using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.UI
{
    [RequireComponent(typeof(Button))]
    public class ButtonInteractabilityChangesTextColor : MonoBehaviour
    {
        protected TextMeshProUGUI Text;
        protected Button Button;
        protected ColorBlock ButtonColors;
        
        protected virtual void Awake()
        {
            Text = GetComponentInChildren<TextMeshProUGUI>();
            Button = GetComponent<Button>();
            ButtonColors = Button.colors;
        }

        public virtual void SetInteractable(bool interactable)
        {
            Button.interactable = interactable;
            Text.color = interactable ? ButtonColors.normalColor : ButtonColors.disabledColor;
        } 
    }
}