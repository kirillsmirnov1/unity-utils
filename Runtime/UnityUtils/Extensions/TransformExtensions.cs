using UnityEngine;

namespace Packages.UnityUtils.Extensions
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
    }
}