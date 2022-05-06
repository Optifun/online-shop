using System.Collections.Generic;

namespace OnlineShop.Client
{
    public static class CollectionExtensions
    {
        public static IList<T> Replace<T>(this IList<T> collection, T old, T @new)
        {
            int id = collection.IndexOf(old);
            if (id == -1)
                return collection;

            collection.RemoveAt(id);
            collection.Insert(id, @new);
            return collection;
        }
    }
}