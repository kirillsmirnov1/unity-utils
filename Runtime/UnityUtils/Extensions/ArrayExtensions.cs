using System;

namespace UnityUtils.Extensions
{
    public static class ArrayExtensions
    {
        public static bool HasElementAtIndex(this Array array, int index)
            => index >= 0 && index < array.Length;
    }
}