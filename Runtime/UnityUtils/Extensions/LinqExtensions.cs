using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace UnityUtils
{
    public static class LinqExtensions
    {
        public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> enumerable) 
            => enumerable.OrderBy(x => Random.Range(0, int.MaxValue));
    }
}