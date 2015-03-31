using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using CustomQueue;

namespace CustomQueue.Tests
{
    [TestClass]
    public class GenericCustomQueueTests
    {
        [TestMethod]
        public void EnqueueDequeueTest()
        {
            GenericCustomQueue<double> q = new GenericCustomQueue<double>();
            Queue<double> q1 = new Queue<double>();


            q.Enqueue(1.8);
            q.Enqueue(2.8);
            q.Enqueue(3.6);
            q.Enqueue(4.8);
            q.Enqueue(5.5);
            q.Enqueue(6.8);

            q1.Enqueue(1.8);
            q1.Enqueue(2.8);
            q1.Enqueue(3.6);
            q1.Enqueue(4.8);
            q1.Enqueue(5.5);
            q1.Enqueue(6.8);

            Assert.AreEqual(q.Count, q1.Count);

            while (q.Count > 0)
            {
                Assert.AreEqual(q.Dequeue(), q1.Dequeue());
            }

            Assert.AreEqual(q.Count, q1.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void DequeueExeptionTest()
        {
            GenericCustomQueue<double> q = new GenericCustomQueue<double>();

            q.Dequeue();
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PeekExeptionTest()
        {
            GenericCustomQueue<double> q = new GenericCustomQueue<double>();

            q.Peek();
        }

        [TestMethod]
        public void PeekIteratorTest()
        {
            GenericCustomQueue<double> q = new GenericCustomQueue<double>();
            Queue<double> q1 = new Queue<double>();


            q.Enqueue(1.8);
            q.Enqueue(2.8);
            q.Enqueue(3.6);
            q.Enqueue(4.8);
            q.Enqueue(5.5);
            q.Enqueue(6.8);

            q1.Enqueue(1.8);
            q1.Enqueue(2.8);
            q1.Enqueue(3.6);
            q1.Enqueue(4.8);
            q1.Enqueue(5.5);
            q1.Enqueue(6.8);

            int count = q.Count;
            Assert.AreEqual(q.Peek(), q.Peek());
            Assert.AreEqual(count, q.Count);

            foreach (var t in q)
            {
                Assert.AreEqual(t, q1.Dequeue(),"iterator");
            }
        }
    }
}
