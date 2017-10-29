using System.Collections.Generic;
using Laboratorium.Core.Containers;

namespace Laboratorium.Models.ViewModels
{
    public class PacketsFilteringViewModel
    {
        public string Script { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsPublic { get; set; }
        public bool IsReusable { get; set; }
    }

    public class PacketsInViewModel
    {
        public PacketsInViewModel()
        {
            Filtering = new PacketsFilteringViewModel();
            Sorting = new Sorting();
        }

        public PacketsFilteringViewModel Filtering { get; set; }
        public Sorting Sorting { get; set; }
        public int CurrentPage { get; set; }
        public bool IsFilterChanged { get; set; }
    }

    public class PacketsOutViewModel
    {
        public PacketsOutViewModel()
        {
            Paging = new Paging();
        }

        public List<PacketItem> Rows { get; set; }
        public Paging Paging { get; set; }
    }

    public class FullPacketViewModel
    {
        public string[] Script { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsPrivate { get; set; }
        public bool IsReusable { get; set; }
    }
}