namespace UnityUtils.Extensions
{
    public static class CollectionsExtensions
    {
        /// <summary>
        /// Is array null or empty
        /// </summary>
        public static bool IsNullOrEmpty<T>(this T[] collection)
        {
            if (collection == null) return true;

            return collection.Length == 0;
        }
    }
}