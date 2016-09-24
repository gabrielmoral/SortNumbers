using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortNumbers.Web.Controllers;
using SortNumbers.Web.Models;
using System.Linq;

namespace SortNumbers.Web.Tests.Controllers
{
    [TestClass]
    public class OrderedElementControllerShould
    {
        [TestMethod]
        public void DoNotCreateModelWithInvalidIntegers()
        {
            var orderedElement = new OrderedElementsController(null);

            var model = new OrderedElement { Numbers = "12323234234234234" };
            orderedElement.Create(model);

            orderedElement.ModelState.IsValid.Should().BeFalse();
            orderedElement.ModelState.Keys.First().Should().Be(nameof(model.Numbers));
        }

        [TestMethod]
        public void DoNotEditModelWithInvalidIntegers()
        {
            var orderedElement = new OrderedElementsController(null);

            var model = new OrderedElement { Numbers = "12323234234234234" };
            orderedElement.Edit(model);

            orderedElement.ModelState.IsValid.Should().BeFalse();
            orderedElement.ModelState.Keys.First().Should().Be(nameof(model.Numbers));
        }
    }
}