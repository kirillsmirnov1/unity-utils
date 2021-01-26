using UnityEngine;

namespace Packages.UnityUtils.Extensions
{
    public static class Vector3Ext
    {
        public static Vector3 Clamp(Vector3 value, Vector3 min, Vector3 max)
        {
            return new Vector3(
                Mathf.Clamp(value.x, min.x, max.x),
                Mathf.Clamp(value.y, min.y, max.y),
                Mathf.Clamp(value.z, min.z, max.z)
                );
        }

        public static Vector3 ClampBy(this Vector3 value, Vector3 min, Vector3 max) 
            => Clamp(value, min, max);
    }
}