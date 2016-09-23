using System.ComponentModel.DataAnnotations;

namespace CsiMediaProject
{
    public enum SortType
    {
        [Display(Name = "Ascending")]
        Asc,

        [Display(Name = "Descending")]
        Desc
    }
}