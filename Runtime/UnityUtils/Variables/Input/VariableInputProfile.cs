using System;
using UnityEngine;
using UnityUtils.Attributes;

namespace UnityUtils.Variables.Input
{
    [CreateAssetMenu(menuName = "Variables/Input/VariableInputProfile", fileName = "VariableInputProfile", order = 0)]
    public class VariableInputProfile : ScriptableObject
    {
        [SerializeField] private Mode mode = Mode.All;

        [ConditionalField("mode", compareValues: new object[] {Mode.All, Mode.Float})] 
        [SerializeField] public int digitsAfterDot = 2;

        [ConditionalField("mode", compareValues: new object[] {Mode.All, Mode.Float})] 
        [SerializeField] public float floatIterationStep = 0.5f;

        [Serializable]
        public enum Mode
        {
            All,
            String,
            Bool,
            Float,
        }
    }
}