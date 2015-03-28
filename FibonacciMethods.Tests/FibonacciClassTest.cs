using System;
using System.Linq;
using FibonacciMethods;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FibonacciMethods.Tests
{
    [TestClass]
    public class FibonacciClassTest
    {
        [TestMethod]
        public void FibonacciTest1()
        {
            CollectionAssert.AreEqual(FibonacciClass.Fibonacci(5).ToArray(), 
                                      new Int64[] { 0, 1, 1, 2, 3 },"5");

            CollectionAssert.AreEqual(FibonacciClass.Fibonacci(0).ToArray(),
                                      new Int64[] { },"0");

            CollectionAssert.AreEqual(FibonacciClass.Fibonacci(10).ToArray(),
                                      new Int64[] { 0, 1, 1, 2, 3, 5, 8, 13, 21, 34 },"10");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void FibonacciExeptionTest()
        {
            var fib = FibonacciClass.Fibonacci(-1).ToArray();
        }

        [TestMethod]
        [ExpectedException(typeof(OverflowException))]
        public void FibonacciOverflowExeption()
        {
            var fib = FibonacciClass.Fibonacci(94).ToArray();
        }

        [TestMethod]
        public void FibonacciHasNoOverflowExeption()
        {
            var fib = FibonacciClass.Fibonacci(93).ToArray();
        }
    }
}
