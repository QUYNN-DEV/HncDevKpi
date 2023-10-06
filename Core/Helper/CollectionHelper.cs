using System.Collections;

namespace Core.Helper
{
    public static class CollectionHelper
    {
        public static bool IsNullOrEmpty(this IList list)
        {
            return list == null || list.Count == 0;
        }
    }
}
