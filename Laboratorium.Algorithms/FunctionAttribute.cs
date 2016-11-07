using System;

namespace Laboratorium.Algorithms
{
    public class FunctionAttribute : Attribute
    {
        private readonly string _alias;
        public FunctionAttribute(string alias)
        {
            _alias = alias;
        }

        public override string ToString()
        {
            return _alias;
        }
    }
}