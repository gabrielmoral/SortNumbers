using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace SortNumbers.Test
{
    [TestClass]
    public class NumberOrdererShould
    {
        [TestMethod]
        public void SortByAscending()
        {
            var numbers = "5,-6,7,2,3";

            string orderedNumbers = NumbersOrderer.SortBy(SortType.Ascending, numbers);

            orderedNumbers.Should().BeEquivalentTo("-6,2,3,5,7");
        }

        [TestMethod]
        public void SortByDescending()
        {
            var numbers = "5,6,7,2,3";

            string orderedNumbers = NumbersOrderer.SortBy(SortType.Descending, numbers);

            orderedNumbers.Should().BeEquivalentTo("7,6,5,3,2");
        }
    }
}