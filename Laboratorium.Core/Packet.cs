using System.Collections.Generic;

namespace Laboratorium.Core
{
    public class Packet
    {
        public Packet()
        {
            Result = new List<string>();
            Errors = new List<string>();
            Input = new List<string>();
        }
        public string Script { get; set; }
        public string ScriptName { get; set; }
        public string User { get; set; }
        public List<string> Result { get; set; }
        public List<string> Errors { get; set; }
        public List<string> Input { get; set; }
    }
}