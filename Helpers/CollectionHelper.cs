using System.Collections.Generic;

namespace Helpers
{
    public static class CollectionHelper
    {
        public static bool IsNullOrEmpty<T>(this ICollection<T> source)
        {
            return source == null || source.Count == 0;
        }
    }
}
