using System;
using System.ComponentModel.DataAnnotations;

namespace CsiMediaProject.Web.Models
{
    public class OrderedElement
    {
        private const string SeparatedCommaNumberRegExpr = @"(\d+)(,*\d+)*";

        [Required]
        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(SeparatedCommaNumberRegExpr)]
        public string Numbers { get; set; }

        [Required]
        [Display(Name = "Sort type")]
        public SortType SortType { get; set; }

        [Required]
        [Display(Name = "Sort duration")]
        public TimeSpan SortDuration { get; set; }
    }
}