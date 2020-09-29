using System;
using UnityEngine;

namespace UnityUtils.Attributes
{
    /// Defines an attribute that makes the array use enum values as labels.
    /// Use like this:
    ///      [NamedArray(typeof(eDirection))] public GameObject[] m_Directions;
    public class NamedArrayAttribute : PropertyAttribute {
        public readonly Type TargetEnum;
        public NamedArrayAttribute(Type targetEnum) => TargetEnum = targetEnum;
    }
}