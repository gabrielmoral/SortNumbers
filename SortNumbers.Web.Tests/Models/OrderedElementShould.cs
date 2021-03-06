﻿using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SortNumbers.Web.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SortNumbers.Web.Tests.Controllers
{
    [TestClass]
    public class OrderedElementShould
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