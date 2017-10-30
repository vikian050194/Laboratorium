using System.Collections.Generic;
using Laboratorium.Models.ViewModels;

namespace Laboratorium.Core.Containers
{
    public class Packet
    {
        public Packet()
        {
            Result = new List<string>();
            Modules = new List<ModuleItem>();
            Packets = new List<PacketItem>();
        }

        public int Id { get; set; }

        public string Script { get; set; }
        public string Title { get; set; }
        public List<string> Result { get; set; }
        public List<ModuleItem> Modules { get; set; }
        public List<PacketItem> Packets { get; set; }

        public bool IsError { get; set; }
        public bool IsPublic { get; set; }
        public bool IsReusable { get; set; }
    }
}