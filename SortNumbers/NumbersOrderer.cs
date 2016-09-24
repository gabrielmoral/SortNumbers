using System.Collections.Generic;
using System.Linq;

namespace SortNumbers
{
    public static class NumbersOrderer
    {
        public static string SortBy(SortType sortType, string numbers)
        {
            return numbers.ConvertToList()
                    .SortWith(sortType, SortBy)
                    .ToText();
        }

        private static IEnumerable<int> SortBy(SortType sortType, IEnumerable<int> numbers)
        {
            if (sortType == SortType.Ascending)
            {
                return numbers.OrderBy(x => x).ToList();
            }
            else
            {
                return numbers.OrderByDescending(x => x).ToList();
            }
        }
    }
}