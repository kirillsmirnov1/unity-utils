using UnityEngine;

namespace UnityUtils
{
    public static class DebugExtensions
    {
        /// <summary>
        /// Draws debug cross
        /// </summary>
        /// <param name="pos">Position in scene</param>
        /// <param name="t">Time to be shown</param>
        /// <param name="l">Edge length</param>
        public static void DrawCross(Vector3 pos, float t = 0.5f, float l = 0.1f) 
        {
            Debug.DrawLine(pos + l * Vector3.left, pos + l * Vector3.right, Color.red, t); 
            Debug.DrawLine(pos + l * Vector3.up, pos + l * Vector3.down, Color.red, t);
            Debug.DrawLine(pos + l * Vector3.forward, pos + l * Vector3.back, Color.red, t);
        }
    }
}