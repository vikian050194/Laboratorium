using System;
using FluentAssertions;
using Laboratorium.Types.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Laboratorium.Tests
{
    [TestClass]
    public class NumericWrapperTest
    {
        [TestMethod]
        public void Constructor_Int_WithoutModule()
        {
            var a = new NumericWrapper<int>(42);

            a.Value
                .Should()
                .Be(42);

            a.IsModule
                .Should()
                .BeFalse();

            a.Module
                .Should()
                .Be(0);
        }

        [TestMethod]
        public void Constructor_Long_WithoutModule()
        {
            var a = new NumericWrapper<long>(42);

            a.Value
                .Should()
                .Be(42);

            a.IsModule
                .Should()
                .BeFalse();

            a.Module
                .Should()
                .Be(0);
        }

        [TestMethod]
        public void Constructor_Decimal_WithoutModule()
        {
            var a = new NumericWrapper<decimal>(42);

            a.Value
                .Should()
                .Be(42);

            a.IsModule
                .Should()
                .BeFalse();

            a.Module
                .Should()
                .Be(0);
        }

        [TestMethod]
        public void Constructor_Double_WithoutModule()
        {
            var a = new NumericWrapper<double>(42);

            a.Value
                .Should()
                .Be(42);

            a.IsModule
                .Should()
                .BeFalse();

            a.Module
                .Should()
                .Be(0);
        }

        [TestMethod]
        public void Addition_Int_WithoutModule()
        {
            var a = new NumericWrapper<int>(3);
            var b = new NumericWrapper<int>(7);

            var result = a + b;

            result.Value
                .Should()
                .Be(10);

            result.IsModule
                .Should()
                .BeFalse();

            result.Module
                .Should()
                .Be(0);
        }

        [TestMethod]
        public void Subtraction_Int_WithoutModule()
        {
            var a = new NumericWrapper<int>(3);
            var b = new NumericWrapper<int>(7);

            var result = a - b;

            result.Value
                .Should()
                .Be(-4);

            result.IsModule
                .Should()
                .BeFalse();

            result.Module
                .Should()
                .Be(0);
        }

        [TestMethod]
        public void Multiplication_Int_WithoutModule()
        {
            var a = new NumericWrapper<int>(3);
            var b = new NumericWrapper<int>(7);

            var result = a * b;

            result.Value
                .Should()
                .Be(21);

            result.IsModule
                .Should()
                .BeFalse();

            result.Module
                .Should()
                .Be(0);
        }

        [TestMethod]
        public void Division_Int_WithoutModule()
        {
            var a = new NumericWrapper<int>(21);
            var b = new NumericWrapper<int>(7);

            var result = a / b;

            result.Value
                .Should()
                .Be(3);

            result.IsModule
                .Should()
                .BeFalse();

            result.Module
                .Should()
                .Be(0);
        }

        [TestMethod]
        public void Module_Int_WithoutModule()
        {
            var a = new NumericWrapper<int>(7);
            var b = new NumericWrapper<int>(3);

            var result = a % b;

            result.Value
                .Should()
                .Be(1);

            result.IsModule
                .Should()
                .BeFalse();

            result.Module
                .Should()
                .Be(0);
        }

        [TestMethod]
        public void Constructor_Int_WithModule()
        {
            var a = new NumericWrapper<int>(42, 17);

            a.Value
                .Should()
                .Be(8);

            a.IsModule
                .Should()
                .BeTrue();

            a.Module
                .Should()
                .Be(17);
        }

        [TestMethod]
        public void Addition_Int_WithModule()
        {
            int m = 4;
            var a = new NumericWrapper<int>(3, m);
            var b = new NumericWrapper<int>(7, m);

            var result = a + b;

            result.Value
                .Should()
                .Be(2);

            result.IsModule
                .Should()
                .BeTrue();

            result.Module
                .Should()
                .Be(m);
        }

        [TestMethod]
        public void Subtraction_Int_WithModule()
        {
            int m = 3;
            var a = new NumericWrapper<int>(7, m);
            var b = new NumericWrapper<int>(15, m);

            var result = a - b;

            result.Value
                .Should()
                .Be(1);

            result.IsModule
                .Should()
                .BeTrue();

            result.Module
                .Should()
                .Be(m);
        }

        [TestMethod]
        public void Multiplication_Int_WithModule()
        {
            int m = 5;
            var a = new NumericWrapper<int>(3, m);
            var b = new NumericWrapper<int>(7, m);

            var result = a * b;

            result.Value
                .Should()
                .Be(1);

            result.IsModule
                .Should()
                .BeTrue();

            result.Module
                .Should()
                .Be(m);
        }

        [TestMethod]
        public void Division_Int_WithModule()
        {
            int m = 5;
            var a = new NumericWrapper<int>(21, m);
            var b = new NumericWrapper<int>(3, m);

            var result = a / b;

            result.Value
                .Should()
                .Be(0);

            result.IsModule
                .Should()
                .BeTrue();

            result.Module
                .Should()
                .Be(m);
        }

        [TestMethod]
        public void Module_Int_WithModule()
        {
            int m = 5;
            var a = new NumericWrapper<int>(21, m);
            var b = new NumericWrapper<int>(3, m);


            var result = a % b;

            result.Value
                .Should()
                .Be(1);

            result.IsModule
                .Should()
                .BeTrue();

            result.Module
                .Should()
                .Be(m);
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Addition_Int_WithDifferentModules1()
        {
            var a = new NumericWrapper<int>(3);
            var b = new NumericWrapper<int>(7, 5);
            
            var result = a + b;
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Addition_Int_WithDifferentModules2()
        {
            var a = new NumericWrapper<int>(3, 4);
            var b = new NumericWrapper<int>(7, 5);

            var result = a + b;
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Subtraction_Int_WithDifferentModules1()
        {
            var a = new NumericWrapper<int>(3);
            var b = new NumericWrapper<int>(7, 5);

            var result = a + b;
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Subtraction_Int_WithDifferentModules2()
        {
            var a = new NumericWrapper<int>(3, 4);
            var b = new NumericWrapper<int>(7, 5);

            var result = a + b;
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Multiplication_Int_WithDifferentModules1()
        {
            var a = new NumericWrapper<int>(3);
            var b = new NumericWrapper<int>(7, 5);

            var result = a * b;
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Multiplication_Int_WithDifferentModules2()
        {
            var a = new NumericWrapper<int>(3, 4);
            var b = new NumericWrapper<int>(7, 5);

            var result = a * b;
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Division_Int_WithDifferentModules1()
        {
            var a = new NumericWrapper<int>(3);
            var b = new NumericWrapper<int>(7, 5);

            var result = a / b;
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Division_Int_WithDifferentModules2()
        {
            var a = new NumericWrapper<int>(3, 4);
            var b = new NumericWrapper<int>(7, 5);

            var result = a / b;
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Module_Int_WithDifferentModules1()
        {
            var a = new NumericWrapper<int>(3);
            var b = new NumericWrapper<int>(7, 5);

            var result = a % b;
        }

        [TestMethod]
        [ExpectedException(typeof(ArithmeticException))]
        public void Module_Int_WithDifferentModules2()
        {
            var a = new NumericWrapper<int>(3, 4);
            var b = new NumericWrapper<int>(7, 5);

            var result = a % b;
        }
    }
}
