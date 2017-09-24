using System.Collections.Generic;
using Laboratorium.Core.Containers;

namespace Laboratorium.Models.ViewModels
{
    public class PacketViewModel
    {
        public PacketViewModel()
        {
            Result = new List<string>();
            Modules = new List<AlgorithmFamilySettingItem>();
        }

        public PacketAction PacketAction { get; set; }
        public string Script { get; set; }
        public string Title { get; set; }
        public List<string> Result { get; set; }
        public bool IsError { get; set; }
        public List<AlgorithmFamilySettingItem> Modules { get; set; }
    }
}