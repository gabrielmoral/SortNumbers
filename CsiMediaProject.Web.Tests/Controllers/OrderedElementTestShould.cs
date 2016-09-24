using CsiMediaProject.Web.Controllers;
using CsiMediaProject.Web.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace CsiMediaProject.Web.Tests.Controllers
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