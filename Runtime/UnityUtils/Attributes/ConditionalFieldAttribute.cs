using System;
using System.Linq;
using UnityEngine;

namespace UnityUtils.Attributes
{
    // Taken from https://github.com/Deadcows/MyBox
    
    /// <summary>
    /// Conditionally Show/Hide field in inspector, based on some other field value 
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ConditionalFieldAttribute : PropertyAttribute
    {
        public readonly string FieldToCheck;
        public readonly string[] CompareValues;
        public readonly bool Inverse;

        /// <param name="fieldToCheck">String name of field to check value</param>
        /// <param name="inverse">Inverse check result</param>
        /// <param name="compareValues">On which values field will be shown in inspector</param>
        public ConditionalFieldAttribute(string fieldToCheck, bool inverse = false, params object[] compareValues)
        {
            FieldToCheck = fieldToCheck;
            Inverse = inverse;
            CompareValues = compareValues.Select(c => c.ToString().ToUpper()).ToArray();
        }
    }
}