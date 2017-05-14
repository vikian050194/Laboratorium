namespace Laboratorium.Core.Containers
{
    internal class AlgorithmFamilyFunction
    {
        public AlgorithmFamilyFunction(string defaultFunction, string customizableFunction)
        {
            DefaultFunction = defaultFunction;
            CustomizableFunction = customizableFunction;
        }

        public bool IsCustomizable { get; set; }

        public string DefaultFunction { get; private set; }

        public string CustomizableFunction { get; private set; }
    }
}