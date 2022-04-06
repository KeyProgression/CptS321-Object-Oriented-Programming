/*
 * Author: Matthew Yien
 * Student ID: 11698797
 */
using NUnit.Framework;

namespace HW3Test
{
    public class Tests
    {
        System.Numerics.BigInteger[] fibSequence;
        public HW3.FibonacciTextReader FibTest = new HW3.FibonacciTextReader(10);
        [SetUp]
        public void Setup()
        {
            fibSequence = new System.Numerics.BigInteger [10];
            fibSequence[0] = new (0UL);
            fibSequence[1] = new (1UL);
            for (int index = 2; index < fibSequence.Length; index++)
            {
                fibSequence[index] = new((ulong)(fibSequence[index - 2] + fibSequence[index - 1]));
            }
        }

        [Test]
        public void Test1()
        { 
            Assert.AreEqual(fibSequence, this.FibTest.FibSequence);
        }
        [Test]
        public void test2()
        {
            Assert.Pass();
        }
    }
}