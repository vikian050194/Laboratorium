using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;

namespace LaboratoriumLib
{
    public class FactorizationTool
    {
        //public FactorizationTool()
        //{
        //    Name = "Факторизация";

        //    Keywords["GCD"] = new Info
        //    {
        //        Title = "Наибольший общий делитель",
        //        Description = "GCD(a<sub>1</sub>,a<sub>2</sub>,...,a<sub>n</sub>)"
        //    };
        //    Keywords["LCM"] = new Info
        //    {
        //        Title = "Наименьшее общее кратное",
        //        Description = "lcm(a<sub>1</sub>,a<sub>2</sub>,...,a<sub>n</sub>)"
        //    };
        //    Keywords["Euclid"] = new Info
        //    {
        //        Title = "Расширенный алгоритм Евклида",
        //        Description = "Euclid(a,b)"
        //    };
        //    Keywords["GaussCriterion"] = new Info
        //    {
        //        Title = "Критерий Гаусса",
        //        Description = "<div>Символ Лежандра</div><div>GaussCriterion(a,n)</div>"
        //    };
        //    Keywords["Fermat"] = new Info
        //    {
        //        Title = "Тест Ферма",
        //        Description = "<div>Fermat(n)</div><div>Fermat(n,iterations)</div>"
        //    };
        //    Keywords["SolovayStrassen"] = new Info
        //    {
        //        Title = "Тест Соловея-Штрассена",
        //        Description = "<div>SolovayStrassen(n)</div><div>SolovayStrassen(n,iterations)</div>"
        //    };
        //    Keywords["RabinMiller"] = new Info
        //    {
        //        Title = "Тест Рабина-Миллера",
        //        Description = "<div>RabinMiller(a,rounds)</div>"
        //    };
        //    //Keywords["cfraction"] = new Info
        //    //{
        //    //    Title = "Цепная дроби",
        //    //    Description = "cfraction(a,b)"
        //    //};
        //}

        //public override string GetToolName()
        //{
        //    return Name;
        //}

        //public override List<string> GetKeyWords()
        //{
        //    return Keywords.Keys.ToList();
        //}

        //public override string Calculate(string query)
        //{
        //    query = query.Replace(" ", "");

        //    var splitedQuery = query.Split(new[] { '(', ',', ')' }, StringSplitOptions.RemoveEmptyEntries).ToList();

        //    var args = new List<string>();

        //    for (var i = 1; i < splitedQuery.Count; i++)
        //    {
        //        args.Add(splitedQuery[i]);
        //    }

        //    switch (splitedQuery[0])
        //    {
        //        case "GCD":
        //            return GreatestCommonDivisor(args).ToString();
        //        case "LCM":
        //            return LeastCommonMultiple(args).ToString();
        //        //case "cfraction":
        //        //    return ContinuedFraction(args);
        //        case "Euclid":
        //            return AdvancedEuclid(args);
        //        case "GaussCriterion":
        //            return GaussCriterion(args);
        //        case "RabinMiller":
        //            return RabinMillerTest(args);
        //        case "Fermat":
        //            return FermatTest(args);
        //        case "SolovayStrassen":
        //            return SolovayStrassenTest(args);
        //        default:
        //            return "Неизвестное ключевое слово";
        //    }
        //}

        //private BigInteger GreatestCommonDivisor(params int[] args)
        //{
        //    var result = BigInteger.Parse(args[0]);

        //    for (var i = 1; i < args.Count && result != 1; i++)
        //    {
        //        var item = BigInteger.Parse(args[i]);

        //        result = BigInteger.GreatestCommonDivisor(result, item);
        //    }

        //    return result;
        //}

        //private BigInteger LeastCommonMultiple(List<string> args)
        //{
        //    CheckArgs(args, 2, Condition.MoreOrEqual);

        //    var result = BigInteger.Parse(args[0]);

        //    for (var i = 1; i < args.Count; i++)
        //    {
        //        var item = BigInteger.Parse(args[i]);

        //        result = result * item / BigInteger.GreatestCommonDivisor(result, item);
        //    }

        //    return result;
        //}

        //private string ContinuedFraction(List<string> args)
        //{
        //    CheckArgs(args, 2, Condition.Equal);

        //    var result = new StringBuilder("[");

        //    var a = BigInteger.Parse(args[0]);
        //    var b = BigInteger.Parse(args[1]);

        //    var r = BigInteger.MinusOne;
        //    var q = BigInteger.MinusOne;

        //    while (r != BigInteger.Zero)
        //    {
        //        q = a / b;
        //        r = a - q * b;

        //        result.AppendFormat("{0},", q);

        //        a = b;
        //        b = r;
        //    }

        //    result = result.Remove(result.Length - 1, 1);

        //    result.Append("]");

        //    return result.ToString();
        //}

        private string AdvancedEuclid(List<string> args)
        {
            CheckArgs(args, 2, Condition.Equal);

            var a = BigInteger.Max(BigInteger.Parse(args[0]), BigInteger.Parse(args[1]));
            var b = BigInteger.Min(BigInteger.Parse(args[0]), BigInteger.Parse(args[1]));

            var table = new Dictionary<string, List<BigInteger>>();
            table["u"] = new List<BigInteger> { 1, 0 };
            table["v"] = new List<BigInteger> { 0, 1 };
            table["r"] = new List<BigInteger> { a, b };
            table["q"] = new List<BigInteger> { 0 };

            var i = 1;

            while (table["r"].Last() != 0)
            {
                table["q"].Add(table["r"][i - 1] / table["r"][i]);
                table["r"].Add(table["r"][i - 1] % table["r"][i]);
                table["u"].Add(table["u"][i - 1] - table["q"][i] * table["u"][i]);
                table["v"].Add(table["v"][i - 1] - table["q"][i] * table["v"][i]);

                i++;
            }

            table["q"].Add(0);

            var result =
                new StringBuilder(
                    "<table style=\"width:100%\" class=\"table table-bordered \"><thead><tr><th>i</th><th>q<sub>i</sub></th><th>u<sub>i</sub></th><th>v<sub>i</sub></th><th>r<sub>i</sub></th></tr></thead>");

            for (var j = 0; j <= i; j++)
            {
                result.AppendFormat("<tr><td>{0}</td><td>{1}</td><td>{2}</td><td>{3}</td><td>{4}</td></tr>",
                    j, table["q"][j], table["u"][j], table["v"][j], table["r"][j]);
            }

            result.Append("</table>");

            return result.ToString();
        }

        private BigInteger GetIterationsValue(List<string> args)
        {
            var n = BigInteger.Parse(args[0]);
            BigInteger iterations;
            var iterationsMaxValue = n - 3;

            if (args.Count == 1)
            {
                iterations = iterationsMaxValue;
            }
            else
            {
                var iterationsValue = BigInteger.Parse(args[1]);
                iterations = iterationsValue < iterationsMaxValue
                    ? iterationsValue
                    : iterationsMaxValue;
            }

            return iterations;
        }

        private string GetResultMessage(BigInteger n, Status status)
        {
            switch (status)
            {
                case Status.Prime:
                    return string.Format("{0} - простое", n);
                case Status.Composite:
                    return string.Format("{0} - составное", n);
                case Status.Unknown:
                    return string.Format("{0} - возможно, простое", n);
                default:
                    return "";
            }
        }

        private string FermatTest(List<string> args)
        {
            CheckArgs(args, 1, Condition.MoreOrEqual);
            CheckArgs(args, 2, Condition.LessOrEqual);

            var n = BigInteger.Parse(args[0]);
            var a = BigInteger.Parse("2");
            var iterations = GetIterationsValue(args);

            for (var i = BigInteger.One; i <= iterations; i++)
            {
                var r = BigInteger.ModPow(a, n, n);

                if (r != a)
                {
                    return GetResultMessage(n, Status.Composite);
                }

                a++;
            }

            return GetResultMessage(n, Status.Unknown);
        }

        private string SolovayStrassenTest(List<string> args)
        {
            CheckArgs(args, 1, Condition.MoreOrEqual);
            CheckArgs(args, 2, Condition.LessOrEqual);

            var n = BigInteger.Parse(args[0]);
            var n1 = n - 1;
            var a = BigInteger.Parse("2");
            var iterations = GetIterationsValue(args);

            for (var i = BigInteger.One; i <= iterations; i++)
            {
                var d = BigInteger.GreatestCommonDivisor(a, n);

                if (d == 1)
                {
                    var r = BigInteger.ModPow(a, n1 / 2, n);

                    if (r != 1 && r != n - 1)
                    {
                        return GetResultMessage(n, Status.Composite);
                    }
                    var s = GaussCriterion(a, n) == -1 ? n1 : 1;

                    if (s != r)
                    {
                        return GetResultMessage(n, Status.Composite);
                    }
                }

                a++;
            }

            return GetResultMessage(n, Status.Unknown);
        }

        private string RabinMillerTest(List<string> args)
        {
            CheckArgs(args, 1, Condition.MoreOrEqual);
            CheckArgs(args, 2, Condition.LessOrEqual);

            var n = BigInteger.Parse(args[0]);
            var n1 = n - 1;
            var a = BigInteger.Parse("2");
            var iterations = GetIterationsValue(args);
            var s = BigInteger.Zero;
            var t = n1;

            while (t % 2 == 0)
            {
                s++;
                t /= 2;
            }

            for (var i = BigInteger.One; i <= iterations; i++)
            {
                var x = BigInteger.ModPow(a, t, n);

                if (x == 1 || x == n1)
                {
                    a++;
                    continue;
                }

                for (var j = BigInteger.One; j < s && x != n1; j++)
                {
                    x = BigInteger.ModPow(x, 2, n);

                    if (x == 1)
                    {
                        return GetResultMessage(n, Status.Composite);
                    }
                    if (x == n1)
                    {
                        break;
                    }
                }

                if (x != n1)
                {
                    return GetResultMessage(n, Status.Composite);
                }

                a++;
            }

            return GetResultMessage(n, Status.Unknown);
        }

        private string GaussCriterion(List<string> args)
        {
            CheckArgs(args, 2, Condition.Equal);

            var a = BigInteger.Parse(args[0]);
            var n = BigInteger.Parse(args[1]);

            return GaussCriterion(a, n).ToString();
        }

        private BigInteger GaussCriterion(BigInteger a, BigInteger n)
        {
            var max = (n - 1) / 2;
            var count = BigInteger.Zero;

            for (var i = BigInteger.One; i <= max; i++)
            {
                var positiveValue = a * i % n;
                var negativeValue = positiveValue - n;
                if (-1 * negativeValue < positiveValue)
                {
                    count++;
                }
            }

            return count % 2 == 0 ? 1 : -1;
        }
    }

    internal enum Status
    {
        Prime,
        Unknown,
        Composite
    }
}