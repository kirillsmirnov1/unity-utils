using UnityEngine;

namespace UnityUtils.Extensions
{
    public static class QuaternionExt
    {
        public static Quaternion LookRotation2D(Vector2 direction, float angleOffset = 0f)
        {
            var angle = LookRotation2DAngle(direction, angleOffset);
            return Quaternion.Euler(0, 0, angle);
        }

        public static float LookRotation2DAngle(Vector2 direction, float angleOffset = 0f) =>
            Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + angleOffset;
    }
}