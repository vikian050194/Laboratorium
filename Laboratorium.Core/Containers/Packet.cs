using System.Collections.Generic;

namespace Laboratorium.Core.Containers
{
    public class Packet
    {
        public Packet()
        {
            Result = new List<string>();
            Modules = new List<AlgorithmFamilySettingItem>();
        }

        public string Script { get; set; }
        public string Title { get; set; }
        public List<string> Result { get; set; }
        public bool IsError { get; set; }
        public List<AlgorithmFamilySettingItem> Modules { get; set; }
    }
}