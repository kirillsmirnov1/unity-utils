﻿using TMPro;
using UnityEngine;

 namespace UnityUtils.Variables.Display
{
    public abstract class XVariableDisplay <T> : MonoBehaviour
    {
        protected abstract XVariable<T> Variable { get; }

        private TextMeshProUGUI _text;
        
        private void Awake()
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
            Variable.OnChange += OnChange;
        }

        private void OnDestroy() => Variable.OnChange -= OnChange;

        private void Start() => SetText(Variable);

        private void SetText(T val) => _text.text = val.ToString();

        private void OnChange(T balance) => SetText(balance);
    }
}