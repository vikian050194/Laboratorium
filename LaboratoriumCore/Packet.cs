using System.Collections.Generic;

namespace LaboratoriumCore
{
    public class Packet
    {
        public Packet()
        {
            Results = new List<string>();
            Errors = new List<string>();
        }
        public string Query { get; set; }
        public List<string> Results { get; set; }
        public List<string> Errors { get; set; }
    }
}