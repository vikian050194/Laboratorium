using System.Collections.Generic;

namespace Laboratorium.Models.ViewModels
{
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
            Sorting = new Sorting();
        }

        public ScriptsFilteringViewModel Filtering { get; set; }
        public Sorting Sorting { get; set; }
        public int CurrentPage { get; set; }
        public bool IsFilterChanged { get; set; }
    }

    public class ScriptsOutViewModel
    {
        public ScriptsOutViewModel()
        {
            Paging = new Paging();
        }

        public List<ScriptViewModel> Rows { get; set; }
        public Paging Paging { get; set; }
    }
}