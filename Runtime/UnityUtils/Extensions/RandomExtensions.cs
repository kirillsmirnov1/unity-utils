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
    }
}