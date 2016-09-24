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
        [DataType(DataType.MultilineText)]
        [RegularExpression(SeparatedCommaNumberRegExpr)]
        public string Numbers { get; set; }

        [Required]
        public SortType SortType { get; set; }

        [Required]
        public TimeSpan SortDuration { get; set; }
    }
}