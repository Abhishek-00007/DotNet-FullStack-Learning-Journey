using Microsoft.VisualStudio.TestTools.UnitTesting;
using CalculatorLibrary;
using System;

namespace CalculatorTests
{
    [TestClass]
    public class CalculatorTests
    {
        private Calculator calculator=null;

        [TestInitialize]
        public void Setup()
        {
            calculator = new Calculator();
        }

        [TestMethod]
        public void Add_ReturnsCorrectResult()
        {
            double result = calculator.Add(5, 3);

            Assert.AreEqual(8, result);
        }

        [TestMethod]
        public void Subtract_ReturnsCorrectResult()
        {
            double result = calculator.Subtract(10, 4);

            Assert.AreEqual(6, result);
        }

        [TestMethod]
        public void Multiply_ReturnsCorrectResult()
        {
            double result = calculator.Multiply(5, 2);

            Assert.AreEqual(10, result);
        }

        [TestMethod]
        public void Divide_ReturnsCorrectResult()
        {
            double result = calculator.Divide(20, 5);

            Assert.AreEqual(4, result);
        }

        [TestMethod]
        public void Divide_ByZero_ThrowsException()
        {
            try
            {
                calculator.Divide(10, 0);

                Assert.Fail("Expected DivideByZeroException was not thrown.");
            }
            catch (DivideByZeroException)
            {
                Assert.IsTrue(true);
            }
        }

        [TestMethod]
        public void Add_Zero_ReturnsSameNumber()
        {
            double result = calculator.Add(7, 0);

            Assert.AreEqual(7, result);
        }

        [TestMethod]
        public void Subtract_Zero_ReturnsSameNumber()
        {
            double result = calculator.Subtract(9, 0);

            Assert.AreEqual(9, result);
        }
    }
}