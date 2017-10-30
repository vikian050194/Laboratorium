using System.Collections.Generic;

namespace Laboratorium.Models.DataModels
{
    public class PacketEntity
    {
        public int Id { get; set; }
        public string Script { get; set; }
        public string Title { get; set; }
        public string Modules { get; set; }
        public string Packets { get; set; }
        public bool IsPublic { get; set; }
        public bool IsReusable { get; set; }

        public string AspNetUserId { get; set; }
        public AspNetUser AspNetUser { get; set; }
    }
}