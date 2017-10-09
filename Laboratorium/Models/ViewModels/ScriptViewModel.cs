using System.Collections.Generic;

namespace Laboratorium.Models.ViewModels
{
    public class PagingViewModel
    {
        public int CurrentPage { get; set; }
        public List<int> Pages { get; set; }
        public bool IsPreviousEnabled { get; set; }
        public bool IsNextEnabled { get; set; }
    }

    public class SortingViewModel
    {
        public bool IsAscending { get; set; }
        public string OrderBy { get; set; }
    }

    public class ScriptViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class ScriptsFilteringViewModel
    {
        public string Code { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
    }

    public class ScriptsInViewModel
    {
        public ScriptsInViewModel()
        {
            Filtering = new ScriptsFilteringViewModel();
            Sorting = new SortingViewModel();
        }

        public ScriptsFilteringViewModel Filtering { get; set; }
        public SortingViewModel Sorting { get; set; }
        public int CurrentPage { get; set; }
        public bool IsFilterChanged { get; set; }
    }

    public class ScriptsOutViewModel
    {
        public ScriptsOutViewModel()
        {
            Paging = new PagingViewModel();
        }

        public List<ScriptViewModel> Rows { get; set; }
        public PagingViewModel Paging { get; set; }
    }
}