using System.Collections.Generic;
using System.Linq;

namespace CsiMediaProject.Test
{
    public class NumberOrderer
    {
        public List<int> SortBy(SortType sortType, List<int> numbers)
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