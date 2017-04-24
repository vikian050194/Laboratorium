using System.Collections.Generic;

namespace Laboratorium.Core.Containers
{
    public class AlgorithmFamilySettingItem
    {
        public AlgorithmFamilySettingItem()
        {
            
        }
        public AlgorithmFamilySettingItem(string name, string info, List<string> functions)
        {
            Name = name;
            Info = info;
            Functions = functions;
        }
        public string Name { get; set; }
        public string Info { get; set; }
        public bool IsEnadled { get; set; }
        public List<string> Functions { get; set; }
    }
}