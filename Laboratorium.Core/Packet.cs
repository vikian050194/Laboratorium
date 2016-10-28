using System.Collections.Generic;

namespace Laboratorium.Core
{
    public class Packet
    {
        public Packet()
        {
            Results = new List<string>();
            Errors = new List<string>();
            Input = new List<string>();
        }
        public string Query { get; set; }
        public string Title { get; set; }
        public List<string> Results { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Input { get; set; }
    }
}