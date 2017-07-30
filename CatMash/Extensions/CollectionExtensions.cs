using System;
using System.Collections.Generic;
using System.Linq;

namespace CatMash.Extensions
{
    public static class CollectionExtensions
    {
        private static Random rng = new Random();

        public static T RandomElement<T>(this IEnumerable<T> list)
        {
            int idx = rng.Next(0, list.Count());
            return list.ElementAt(idx);
        }

        public static T RandomElement<T>(this T[] array)
        {
            return array[rng.Next(array.Length)];
        }
    }
}
