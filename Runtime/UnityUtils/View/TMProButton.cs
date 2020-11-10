using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UnityUtils.View
{
    public class TMProButton : Button
    {
        private TextMeshProUGUI[] _text;
        private Color[] _defaultColors;
        protected override void Awake()
        {
            base.Awake();
            InitTextComponents();
        }

        private void InitTextComponents()
        {
            _text = GetComponentsInChildren<TextMeshProUGUI>();
            if (_text == null || _text.Length == 0) return;
            _defaultColors = _text.Select(x => x.color).ToArray();
        }

        public bool Interactable
        {
            get => interactable;
            set
            {
                var colorBlock = colors;
                interactable = value;
                for (var i = 0; i < _text.Length; i++)
                {
                    _text[i].color = interactable ? _defaultColors[i] : _defaultColors[i] + colorBlock.disabledColor;
                }
            }
        }
    }
}