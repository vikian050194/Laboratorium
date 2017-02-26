using System.Collections.Generic;

namespace Laboratorium.Core.AlgorithmsLibrary
{
    public class AlgorithmFamilySettingItem
    {
        public AlgorithmFamilySettingItem()
        {
            
        }
        public AlgorithmFamilySettingItem(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
        public bool IsEnadled { get; set; }
    }

    internal class AlgorithmFamily
    {
        public AlgorithmFamily(string familyName, string familyNamespace)
        {
            Name = familyName;
            Namespace = familyNamespace;
            Functions = new List<AlgorithmFamilyFunction>();
        }

        public string Name { get; private set; }
        public string Namespace { get; private set; }
        public string Open => "open " + Namespace;
        public string Adapter { get; set; }

        public List<AlgorithmFamilyFunction> Functions { get; }
    }
}