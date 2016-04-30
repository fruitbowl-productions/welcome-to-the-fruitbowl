using System.Collections.Generic;

namespace WelcomeToTheFruitBowl.Utilities
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ReverseInPlace<T>(this IEnumerable<T> list)
        {
            var newList = new List<T>(list);
            newList.Reverse();
            return newList;
        }
    }
}
