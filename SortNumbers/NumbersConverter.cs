using System;
using System.Collections.Generic;
using System.Linq;

namespace SortNumbers
{
    internal static class NumbersConverter
    {
        private const string separator = ",";

        internal static IEnumerable<int> ConvertToList(this string numbers)
        {
            var numberSeparator = new string[] { separator };

            return numbers.Split(numberSeparator, StringSplitOptions.None)
                          .Select(x => Convert.ToInt32(x));
        }

        internal static IEnumerable<int> SortWith(this IEnumerable<int> numbers, SortType sortType, Func<SortType, IEnumerable<int>, IEnumerable<int>> orderFunction)
        {
            return orderFunction(sortType, numbers);
        }

        internal static string ToText(this IEnumerable<int> orderedNumbers)
        {
            return string.Join(separator, orderedNumbers.Select(x => x.ToString()));
        }
    }
}