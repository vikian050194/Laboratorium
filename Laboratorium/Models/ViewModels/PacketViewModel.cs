using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Laboratorium.Core.Containers;

namespace Laboratorium.Models.ViewModels
{
    public class PacketViewModel
    {
        public PacketViewModel()
        {
            Result = new List<string>();
            Modules = new List<ModuleItem>();
            Packets = new List<PacketItem>();
        }

        public PacketAction PacketAction { get; set; }

        public int Id { get; set; }

        [Display(Name = @"Название")]
        public string Title { get; set; }
        public string Script { get; set; }
        public List<string> Result { get; set; }
        public List<ModuleItem> Modules { get; set; }
        public List<PacketItem> Packets { get; set; }
        public bool IsError { get; set; }

        [Display(Name = @"Общедоступный")]
        public bool IsPublic { get; set; }

        [Display(Name = @"Переиспользуемый")]
        public bool IsReusable { get; set; }
    }
}