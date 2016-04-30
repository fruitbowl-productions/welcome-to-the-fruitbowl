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

        public static string Combine(this IEnumerable<string> list)
        {
            var result = new StringBuilder();

            foreach (var item in list)
            {
                result.Append(item);
            }

            return result.ToString();
        }

        public static IEnumerable<string> SplitEvery(this string thisString, int n)
        {
            var tempString = string.Copy(thisString);
            var result = new List<string>();

            while (tempString != "")
            {
                if (tempString.Length > n)
                {
                    result.Add(tempString.Substring(0, n));
                    tempString = tempString.Substring(n);
                }
                else
                {
                    result.Add(tempString);
                    tempString = "";
                }
            }

            return result;
        }
    }
}