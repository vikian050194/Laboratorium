using System;

namespace Laboratorium.Attributes
{
    public class FunctionAliasAttribute : Attribute
    {
        public string Alias { get; }

        public FunctionAliasAttribute(string alias)
        {
            Alias = alias;
        }

        public override string ToString()
        {
            return Alias;
        }
    }
}