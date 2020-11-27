using UnityEngine;

namespace UnityUtils
{
    public static class RandomExtensions
    {
        /// <summary>
        /// Separates [from, to] to segmentCount ranges and generates random value in segmentIndex range
        /// <para>segmentIndex = [0, segmentCount-1]</para> 
        /// </summary>
        public static float RandomValueInRangeSegment(float from, float to, int segmentCount, int segmentIndex)
        {
            float step = (to - from) / segmentCount;
            float min = from + step * ((segmentCount - 1) - segmentIndex);
            float max = to + step * ((segmentCount - 2) - segmentIndex);

            return Random.Range(min, max);
        }

        public static Vector3 NextVector(this System.Random rand, Vector3 from, Vector3 to) 
            => new Vector3(
                rand.NextFloat(from.x, to.x),
                rand.NextFloat(from.y, to.y),
                rand.NextFloat(from.z, to.z)
            );

        public static float NextFloat(this System.Random rand, float from, float to) 
            => Mathf.Lerp(from, to, rand.NextFloat());

        public static float NextFloat(this System.Random rand) => (float) rand.NextDouble();
    }
}