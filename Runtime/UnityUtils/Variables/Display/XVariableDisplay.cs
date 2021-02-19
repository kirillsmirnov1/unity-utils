﻿using TMPro;
using UnityEngine;

 namespace UnityUtils.Variables.Display
{
    public abstract class XVariableDisplay <T> : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] private string prefix;
        [SerializeField] private string postfix;
#pragma warning restore 0649
        
        protected abstract XVariable<T> Variable { get; }

        private TextMeshProUGUI _text;
        
        private void Awake()
        {
            _text = GetComponentInChildren<TextMeshProUGUI>();
            Variable.OnChange += OnChange;
        }

        private void OnDestroy() => Variable.OnChange -= OnChange;

        private void Start() => SetText(Variable);

        private void SetText(T val) => _text.text = prefix + val.ToString() + postfix;

        private void OnChange(T balance) => SetText(balance);
    }
}