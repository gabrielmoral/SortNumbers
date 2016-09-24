using CsiMediaProject.Web.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CsiMediaProject.Web.Tests.Controllers
{
    [TestClass]
    public class OrderedElementTestShould
    {
        [TestMethod]
        public void BeInvalidIfNumberDoNotMatchPattern()
        {
            var orderedElement = new OrderedElement
            {
                Numbers = "1,2 3",
                SortType = SortType.Ascending
            };

            Validator.TryValidateObject(orderedElement,
                                        new ValidationContext(orderedElement),
                                        new List<ValidationResult>(),
                                        true)
                     .Should().BeFalse();
        }

        [TestMethod]
        public void BeValidIfNumberDoNotMatchPattern()
        {
            var orderedElement = new OrderedElement
            {
                Numbers = "1,2,3",
                SortType = SortType.Ascending
            };

            Validator.TryValidateObject(orderedElement,
                                        new ValidationContext(orderedElement),
                                        new List<ValidationResult>(),
                                        true)
                     .Should().BeTrue();
        }
    }
}