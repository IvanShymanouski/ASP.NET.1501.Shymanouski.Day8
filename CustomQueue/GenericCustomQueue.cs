using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomQueue
{
    public class GenericCustomQueue<T> : IEnumerable<T>
    {
        #region fields
        private class Queque
        {            
            public T value;
            public Queque next;
            public Queque previous;

            public Queque(T value) 
            {
                this.value = value;
            }
        }
        private Queque first;
        private Queque last;

        public int Count { get; private set; }
        #endregion

        public GenericCustomQueue() { }

        #region public functions
        public void Enqueue(T item) 
        {
            Queque temp = new Queque(item);
            if (Count > 0)
            {
                last.next = temp;
                temp.previous = last;
                last = temp;
                Count++;
            }
            else
            {
                first = last = temp;
                Count++;
            }
        }

        public T Dequeue()
        {            
            if (Count <= 0)
            {
                throw new InvalidOperationException("Queue empty");
            }
            Count--;

            T returnValue = first.value;
            first = first.next;

            return returnValue;
        }

        public T Peek() 
        {
            if (Count <= 0)
            {
                throw new InvalidOperationException("Queue empty");
            }

            return first.value;
        }
        #endregion

        public IEnumerator<T> GetEnumerator()
        {
            Queque temp=first;
            for (int i = 0; i < Count; i++)
            {
                yield return temp.value;
                temp = temp.next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}


0 1 2
|   |
f   l