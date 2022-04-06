// <copyright file="ExpressionTreeTests.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace ExpreesionTreeTests
{
    using System.Globalization;
    using CptS321;
    using NUnit.Framework;

    public class Tests
    {
        /// <summary>
        /// Run's before every Test.
        /// </summary>
        [SetUp]
        public void Setup()
        {
        }

        /// <summary>
        /// Testing normal cases.
        /// </summary>
        /// <param name="exp"> Passing in the parameter of the test cases.</param>
        /// <returns>Returns the Evaluation of the test.</returns>
        [Test]
        [TestCase("3+5", ExpectedResult = 8.0)]
        [TestCase("12-12-3/3", ExpectedResult = 1.0)]
        [TestCase("(10+2)*12", ExpectedResult = 144.0)]
        [TestCase("5-10",ExpectedResult = -5.0)]

        public double TestEvaluateNormalCases(string exp)
        {
            ExpressionTree expression = new (exp);
            return expression.Evaluate();
        }

        /// <summary>
        /// Test boundary case, max value.
        /// </summary>
        [Test]
        public void TestMaxValue()
        {
            string maxValue = double.MaxValue.ToString("F", CultureInfo.InvariantCulture);
            double result = new ExpressionTree($"{maxValue}+ {maxValue}").Evaluate();
            Assert.True(double.IsInfinity(result));
        }

        /// <summary>
        /// Test divide by 0.
        /// </summary>
        /// <returns>Should return a positivie infinity value</returns>
        [Test]
        [TestCase("100/0",ExpectedResult = double.PositiveInfinity)]
        public double TestDivideByZeroCases(string exp)
        {
            ExpressionTree expression = new (exp);
            return expression.Evaluate();
        }
    }
}