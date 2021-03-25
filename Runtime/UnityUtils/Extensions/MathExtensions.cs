using UnityEngine;

namespace UnityUtils.Extensions
{
    public static class MathExtensions
    {
        public static Vector2 RadianToVector2(float radian)
        {
            return new Vector2(Mathf.Cos(radian), Mathf.Sin(radian));
        }
  
        public static Vector2 DegreeToVector2(float degree)
        {
            return RadianToVector2(degree * Mathf.Deg2Rad);
        }

        /// <summary>
        /// Counts full circle counter clock wise from (1, 0)
        /// </summary>
        public static float ToAngleInDegrees(this Vector2 v)
        {
            var angle = Vector2.Angle(Vector2.right, v);
            if (v.y < 0) angle = 360 - angle;
            return angle;
        }
        
        /// <summary>
        /// Counts full circle counter clock wise from (1, 0)
        /// </summary>
        public static float ToAngleInRadians(this Vector2 v) 
            => ToAngleInDegrees(v) * Mathf.Deg2Rad;
    }
}