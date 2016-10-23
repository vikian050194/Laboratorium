using System.Collections.Generic;

namespace Laboratorium.Models.ViewModels
{
    public class PacketViewModel
    {
        public PacketViewModel()
        {
            Result = new List<string>();
            Errors = new List<string>();
        }
        public string Script { get; set; }
        public List<string> Result { get; set; }
        public List<string> Errors { get; set; }
    }
}