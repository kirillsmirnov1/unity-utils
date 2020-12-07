﻿using UnityEngine;

 namespace UnityUtils.Variables.Display
{
    public class ULongVariableDisplay : XVariableDisplay<ulong>
    {
#pragma warning disable 0649
        [SerializeField] private ULongVariable variable;
#pragma warning restore 0649
        protected override XVariable<ulong> Variable => variable;
    }
}