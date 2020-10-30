using UnityEngine;

namespace UnityUtils.Extensions
{
    public static class ColliderExtensions
    {
        public static Vector2 ClosestPointOnCollider(this Collider2D col, Vector2 pos)
        {
            Vector2 colliderPos = col.transform.position;
            Vector2 point;

            while ((point = col.ClosestPoint(pos)) == pos)
            {
                var mod = pos - colliderPos;
                mod *= 2;
                pos = colliderPos + mod;
            }

            return point;
        }
        
        public static Vector3 ClosestPointOnCollider(this Collider col, Vector3 pos)
        {
            Vector3 colliderPos = col.transform.position;
            Vector3 point;

            while ((point = col.ClosestPoint(pos)) == pos)
            {
                var mod = pos - colliderPos;
                mod *= 2;
                pos = colliderPos + mod;
            }

            return point;
        }
    }
}