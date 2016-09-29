using System;
using LaboratoriumTypeLib;

namespace LaboratoriumConverter
{
    public class Converter : IConverter
    {
        public MathObject Convert(string line)
        {
            var s = line.Split(new [] {'(', ')'}, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}