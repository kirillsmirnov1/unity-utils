using System;

namespace UnityUtils
{
    public static class EnumExtensions 
    {
        public static T Next<T>(this T src) where T : Enum
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException($"Argument {typeof(T).FullName} is not an Enum");
            }

            var values = (T[])Enum.GetValues(src.GetType());
            var j = Array.IndexOf(values, src) + 1;
            return (values.Length==j) ? values[0] : values[j];            
        }
    }
}