using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;

namespace SortNumbers.Web.Models
{
    public class OrderedElement
    {
        private const string SeparatedCommaNumberRegExpr = @"(-?)(\d+)(,-?\d+)*";

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(SeparatedCommaNumberRegExpr, ErrorMessage = "Invalid integers. Example: 1,-2,4,2")]
        [DataType(DataType.MultilineText)]
        public string Numbers { get; set; }

        [Required]
        [Display(Name = "Sort type")]
        public SortType SortType { get; set; }

        [Required]
        [Display(Name = "Sort duration")]
        public TimeSpan SortDuration { get; set; }

        public void Sort()
        {
            var watch = new Stopwatch();
            watch.Start();

            this.Numbers = NumbersOrderer.SortBy(SortType, this.Numbers);

            watch.Stop();
            this.SortDuration = watch.Elapsed;
        }
    }
}