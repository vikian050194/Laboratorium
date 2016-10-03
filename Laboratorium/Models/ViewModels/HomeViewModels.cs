using System.Collections.Generic;

namespace Laboratorium.Models.ViewModels
{
    public class PacketViewModel
    {
        public PacketViewModel()
        {
            Results = new List<string>();
            Errors = new List<string>();
        }
        public string Query { get; set; }
        public List<string> Results { get; set; }
        public List<string> Errors { get; set; }
    }
}