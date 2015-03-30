using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BinarySearchLibrary;

namespace BinarySearchLibrary.Tests
{
    [TestClass]
    public class BinarySearchClassTests
    {
        [TestMethod]
        public void BinarySearchTest1()
        {
            List<double> mas = new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8 };
            Assert.AreEqual(mas.ToArray().BinarySearch(3, (a, b) => (int)(a - b)), 2);
            Assert.AreEqual(mas.ToArray().BinarySearch(10, (a, b) => (int)(a - b)), -1);
            Assert.AreEqual(mas.ToArray().BinarySearch(-100, (a, b) => (int)(a - b)), -1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void BinarySearchExeptionTest1()
        {
            List<double> mas = new List<double>() { 1, 2, 3, 4, 5, 6, 7, 8 };

            Assert.AreEqual(mas.ToArray().BinarySearch(0, null), -1);
        }

    }
}
