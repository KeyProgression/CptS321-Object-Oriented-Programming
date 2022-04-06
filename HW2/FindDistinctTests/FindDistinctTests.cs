// <copyright file="FindDistinctTest.cs" company="WSU-Dr. Venera Arnaoudova">
// Copyright (c) WSU-Dr. Venera Arnaoudova. All rights reserved.
// </copyright>
// <author>Matthew Yien</author>
// <studentid>11698797</studentid>

using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace FindDistinctTests
{
     /// <summary>
    /// Tests all methods against List.distinct().
    /// </summary>
    public class FindDistinctTests
    {
        HW2.FindDistinct testObj = null;
        [SetUp]
        /// <summary>
        /// Creates a FindDistinct object as testObj and fills it with numbers 1 to 10000.
        /// </summary>
        public void Setup()
        {
            List<int> testList = new List<int>(10000);

            for (int i = 1; i <= 10000;i++)
            {
                testList.Add(i);
            }
            testObj = new HW2.FindDistinct(testList);
        }

        [Test]

        // Tests all methods against a static 10000, system.Distinct(), and the other methods in FindDistinct
        public void TestHashSetMethod()
        {
            Assert.AreEqual(10000,testObj.DistinctHashMethod());
            Assert.AreEqual(testObj.GetsRandomList.Distinct().Count(), testObj.DistinctHashMethod());
            Assert.AreEqual(testObj.SortedListMethod(), testObj.DistinctHashMethod());
            Assert.AreEqual(testObj.StaticListMethod(), testObj.DistinctHashMethod());

        }

        [Test]
        public void TestSortedListMethod()
        {
            Assert.AreEqual(10000, testObj.SortedListMethod());
            Assert.AreEqual(testObj.GetsRandomList.Distinct().Count(), testObj.SortedListMethod());
            Assert.AreEqual(testObj.DistinctHashMethod(), testObj.SortedListMethod());
            Assert.AreEqual(testObj.StaticListMethod(), testObj.SortedListMethod());
        }

        [Test]
        public void TestO1Method()
        {
            Assert.AreEqual(10000, testObj.StaticListMethod());
            Assert.AreEqual(testObj.GetsRandomList.Distinct().Count(), testObj.StaticListMethod());
            Assert.AreEqual(testObj.DistinctHashMethod(), testObj.StaticListMethod());
            Assert.AreEqual(testObj.SortedListMethod(), testObj.StaticListMethod());
        }
    }
}
