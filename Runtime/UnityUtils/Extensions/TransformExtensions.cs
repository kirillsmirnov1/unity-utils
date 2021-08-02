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
    }
}