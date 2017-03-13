using System.Collections.Generic;

namespace Laboratorium.Core.AlgorithmsLibrary
{
    public class AlgorithmFamilySettingItem
    {
        public AlgorithmFamilySettingItem()
        {
            
        }
        public AlgorithmFamilySettingItem(string name, List<string> functions)
        {
            Name = name;
            Functions = functions;
        }
        public string Name { get; set; }
        public bool IsEnadled { get; set; }
        public List<string> Functions { get; set; }
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