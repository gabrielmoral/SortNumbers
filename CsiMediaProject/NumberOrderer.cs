using System.Collections.Generic;
using System.Linq;

namespace CsiMediaProject.Test
{
    public class NumberOrderer
    {
        public List<int> SortBy(SortType sortType, List<int> numbers)
        {
            if (sortType == SortType.Asc)
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