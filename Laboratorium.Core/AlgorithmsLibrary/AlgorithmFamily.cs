using System.Collections.Generic;

namespace Laboratorium.Core
{
    internal class AlgorithmFamily
    {
        public AlgorithmFamily(string familyName, string familyNamespace)
        {
            Name = familyName;
            Namespace = familyNamespace;
            Functions = new List<AlgorithmFamilyFunction>();
        }

        public string Name { get; private set; }
        public string Namespace { get; set; }
        public string Adapter { get; set; }

        public List<AlgorithmFamilyFunction> Functions { get; }
    }
}