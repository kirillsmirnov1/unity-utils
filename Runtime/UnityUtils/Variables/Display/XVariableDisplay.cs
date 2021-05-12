﻿using TMPro;
using UnityEngine;

 namespace UnityUtils.Variables.Display
{
    public abstract class XVariableDisplay <T> : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] protected XVariable<T> variable;
        [SerializeField] private string prefix;
        [SerializeField] private string postfix;
#pragma warning restore 0649
        
        private TextMeshProUGUI _text;
        
        private void Awake()
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
            variable.OnChange += OnChange;
        }

        private void OnDestroy() => variable.OnChange -= OnChange;

        private void Start() => SetText(variable);

        private void SetText(T value) => _text.text = $"{prefix}{value.ToString()}{postfix}";

        private void OnChange(T value) => SetText(value);
    }
}