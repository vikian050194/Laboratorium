using FluentAssertions;
using Laboratorium.Algorithms.Factorization.Common.EuclideanAlgorithm;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Laboratorium.Tests
{
    [TestClass]
    public class FactorizationTest
    {
        [TestMethod]
        public void EuclideanAlgorithm_1()
        {
            var gcd = new EuclideanAlgorithm();
            var a = 128;
            var b = 112;

            gcd.Execute(a, b)
                .Should()
                .Be(16);
        }
    }
}
