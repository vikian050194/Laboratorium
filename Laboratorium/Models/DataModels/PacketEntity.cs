using System.Collections.Generic;

namespace Laboratorium.Models.DataModels
{
    public class PacketEntity
    {
        public PacketEntity()
        {
            Modules = new List<string>();
            Packets = new List<int>();
        }

        public int Id { get; set; }
        public string Script { get; set; }
        public string Title { get; set; }
        public List<string> Modules { get; set; }
        public List<int> Packets { get; set; }
        public bool IsPublic { get; set; }
        public bool IsReusable { get; set; }

        public string AspNetUserId { get; set; }
        public AspNetUser AspNetUser { get; set; }
    }
}