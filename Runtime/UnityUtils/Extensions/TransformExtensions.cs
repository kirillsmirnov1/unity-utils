using System.Collections.Generic;
using UnityEngine;

namespace UnityUtils.Extensions
{
    public static class TransformExtensions
    {
        public static void DestroyChildren(this Transform transform)
        {
            for (var i = 0; i < transform.childCount; i++)
            {
                Object.Destroy(transform.GetChild(i).gameObject);
            }
        }
        
        public static bool UpsideDown(this Transform transform) => transform.up.y < 0;
        
        public static List<T> GetComponentsInFirstChildrenLayer<T>(this Transform parent) 
        {
            var result = new List<T>();
            for (int i = 0; i < parent.childCount; i++)
            {
                var elem = parent.GetChild(i).GetComponent<T>();
                if (elem != null)
                {
                    result.Add(elem);
                }
            }
            return result;
        }
    }
}