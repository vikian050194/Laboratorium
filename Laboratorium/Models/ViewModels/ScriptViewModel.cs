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

    public class ScriptsListSearch
    {
        public string CodeSearch { get; set; }
        public string TitleSearch { get; set; }
        public string AuthorSearch { get; set; }
    }

    public class ScriptsListOrder
    {
        public bool CodeOrder { get; set; }
        public bool TitleOrder { get; set; }
        public bool AuthorOrder { get; set; }
    }

    public class ScriptsViewModel
    {
        public List<ScriptViewModel> ScriptsList { get; set; }

        public ScriptsListOrder Order { get; set; }

        public ScriptsListSearch Search { get; set; }

        public int PageNumber { get; set; }
    }
}