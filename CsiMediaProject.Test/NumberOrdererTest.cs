using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace CsiMediaProject.Test
{
    [TestClass]
    public class NumberOrdererTestShould
    {
        [TestMethod]
        public void SortByAscending()
        {
            var numbers = new List<int>() { 5, 6, 7, 2, 3 };

            var orderer = new NumberOrderer();
            List<int> orderedNumbers = orderer.SortBy(SortType.Asc, numbers);

            orderedNumbers.Should().BeEquivalentTo(new List<int>() { 2, 3, 5, 6, 7 });
        }

        [TestMethod]
        public void SortByDescending()
        {
            var numbers = new List<int>() { 5, 6, 7, 2, 3 };

            var orderer = new NumberOrderer();
            List<int> orderedNumbers = orderer.SortBy(SortType.Desc, numbers);

            orderedNumbers.Should().BeEquivalentTo(new List<int>() { 7, 6, 5, 3, 2 });
        }
    }
}