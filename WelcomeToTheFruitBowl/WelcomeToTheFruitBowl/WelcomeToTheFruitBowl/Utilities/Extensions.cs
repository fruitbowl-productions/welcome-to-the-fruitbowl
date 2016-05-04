using System.Collections.Generic;
using System.Text;

namespace WelcomeToTheFruitBowl.Utilities
{
    public static class Extensions
    {
        public static IEnumerable<T> ReverseInPlace<T>(this IEnumerable<T> list)
        {
            var newList = new List<T>(list);
            newList.Reverse();
            return newList;
        }
    }
}