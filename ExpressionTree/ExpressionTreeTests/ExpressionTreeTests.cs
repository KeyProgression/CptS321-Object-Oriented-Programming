using NUnit.Framework;
using System.Globalization;

namespace ExpressionTreeTests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        [TestCase("3+5", ExpectedResult = 8.0)]
        [TestCase("12-12+3/3", ExpectedResult = 1.0)]
        [TestCase("1 + 1 + 1 * 0", ExpectedResult = 2.0)]
        [TestCase("(10+2)*12", ExpectedResult = 144.0)]
        [TestCase("5-10", ExpectedResult = -5.0)]

        public double TestEvaluateNormalCases(string exp)
        {
            ExpressionTreeCodeDemo.Expression code = new (exp);
            return code.Evaluate();
        }

        [Test]
        [TestCase("100/0", ExpectedResult = double.PositiveInfinity)]
        public double TestDivideZeroCases(string exp)
        {
            ExpressionTreeCodeDemo.Expression code = new(exp);
            return (code.Evaluate());
        }
        // Refactor to something more descriptive such as an UnsupportedOperatorException
        [TestCase("4%2")]
        public void TestEvaluateUnsupportedOperator(string expression)
        {
            ExpressionTreeCodeDemo.Expression exp = new(expression);
            Assert.That(()=> exp.Evaluate(), Throws.TypeOf<System.Collections.Generic.KeyNotFoundException>());
        }

        // Test unsupported operators %
        // Test Infinity
        [Test]
        public void TestInfinity()
        {
            string maxValue = (double.MaxValue).ToString("F", CultureInfo.InvariantCulture);
            double result = new ExpressionTreeCodeDemo.Expression($"{maxValue}+ {maxValue}").Evaluate();
            Assert.True(double.IsInfinity(result));
        }
        // Test invalid expressions
    }
}