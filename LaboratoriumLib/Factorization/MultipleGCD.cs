using System.Linq;

namespace LaboratoriumLib.Factorization
{
    public class MultipleGCD : IAlgorithm
    {
        private int[] _args;
        public MultipleGCD(params int[] args)
        {
            _args = args;
        }
        public int Execute()
        {
            var result = _args.First();

            for (var i = 1; i < _args.Length && result != 1; i++)
            {
                result = new SingleGCD(result, _args[i]).Execute();
            }

            return result;
        }
    }
}
