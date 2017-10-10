using System.Collections.Generic;

namespace Laboratorium.Models.ViewModels
{
    public class Paging
    {
        public int CurrentPage { get; set; }
        public List<int> Pages { get; set; }
        public bool IsPreviousEnabled { get; set; }
        public bool IsNextEnabled { get; set; }
    }
}