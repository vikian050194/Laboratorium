using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using Laboratorium.Attributes;

namespace Laboratorium.Algorithms.Factorization.Common.EuclideanAlgorithm
{
    public interface IAdvancedEuclideanAlgorithm
    {
        List<TableRow> Execute(BigInteger a, BigInteger b);
    }

    [FunctionAlias("euclid")]
    [DefaultImplementation]
    public class AdvancedEuclideanAlgorithm : IAdvancedEuclideanAlgorithm
    {
        public List<TableRow> Execute(BigInteger a, BigInteger b)
        {
            if (b > a)
            {
                var t = a;
                a = b;
                b = t;
            }

            var table = new List<TableRow>
            {
                new TableRow
                {
                    U = 1,
                    V = 0,
                    R = a,
                    Q = 0
                },
                new TableRow
                {
                    U = 0,
                    V = 1,
                    R = b,
                    Q = new BigInteger()
                }
            };

            for (int i = 1; table.Last().R != 0; i++)
            {
                table.Last().Q = table[i - 1].R / table[i].R;
                table.Add(new TableRow());
                table.Last().R = table[i - 1].R % table[i].R;
                table.Last().U = table[i - 1].U - table[i].Q * table[i].U;
                table.Last().V = table[i - 1].V - table[i].Q * table[i].V;
            }

            table.Last().Q = 0;

            return table;
        }
    }
}