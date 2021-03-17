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

        protected bool Initiated;

        public bool interactable
        {
            get => Button.interactable;
            set => SetInteractable(value);
        }
        
        protected virtual void Awake()
        {
            Init();
            SetInteractable(Button.interactable);
        }

        protected virtual void Init()
        {
            Text = GetComponentInChildren<TextMeshProUGUI>();
            Button = GetComponent<Button>();
            ButtonColors = Button.colors;
            Initiated = true;
        }

        public virtual void SetInteractable(bool newStatus)
        {
            if(!Initiated) Init();
            Button.interactable = newStatus;
            Text.color = newStatus ? ButtonColors.normalColor : ButtonColors.disabledColor;
        } 
    }
}