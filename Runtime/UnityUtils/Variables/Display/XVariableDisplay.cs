﻿using TMPro;
using UnityEngine;

 namespace UnityUtils.Variables.Display
{
    public abstract class XVariableDisplay <T> : MonoBehaviour
    {
#pragma warning disable 0649
        [SerializeField] protected XVariable<T> variable;
        [SerializeField] protected string prefix;
        [SerializeField] protected string postfix;
#pragma warning restore 0649
        
        protected TextMeshProUGUI Text;
        
        protected virtual void Awake()
        {
            Text = GetComponentInChildren<TextMeshProUGUI>();
            variable.OnChange += OnChange;
        }

        protected virtual void OnDestroy() => variable.OnChange -= OnChange;

        protected virtual void Start() => SetText(variable);

        protected virtual void SetText(T value) => Text.text = $"{prefix}{value.ToString()}{postfix}";

        protected virtual void OnChange(T value) => SetText(value);
    }
}