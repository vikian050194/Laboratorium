using System.Collections.Generic;
using Laboratorium.Core.AlgorithmsLibrary;

namespace Laboratorium.Core
{


    public class Packet
    {
        public Packet()
        {
            Result = new List<string>();
            Errors = new List<string>();
            File = new List<string>();
            Modules = new List<AlgorithmFamilySettingItem>();
        }

        public string Script { get; set; }
        public List<string> Result { get; set; }
        public List<string> Errors { get; set; }
        public List<string> File { get; set; }
        public List<AlgorithmFamilySettingItem> Modules { get; set; }
    }
}