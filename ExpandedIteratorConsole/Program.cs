using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpandedIterator
{
    class Program
    {
        static void Main(string[] args)
        {
            
            Console.WriteLine("--List--");
            List<int> collectionOfInt = new List<int>();

            collectionOfInt.Add(1);
            collectionOfInt.Add(2);
            collectionOfInt.Add(3);
            collectionOfInt.Add(4);
            collectionOfInt.Add(5);

            foreach (var element in collectionOfInt.GetExpandedIterator((x, y) => x % 2 == 0))
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("--Queue--");
            Queue<double> collectQ = new Queue<double>();

            collectQ.Enqueue(1.8);
            collectQ.Enqueue(2.8);
            collectQ.Enqueue(3.6);
            collectQ.Enqueue(4.8);
            collectQ.Enqueue(5.5);
            collectQ.Enqueue(6.8);

            
            

            foreach (var element in collectQ.GetExpandedIterator((x, y) => (x % 2 == 0) && (Math.Abs(y - (int)(y)) < 0.60001)))
            {
                Console.WriteLine(element);
            }


            Console.WriteLine("--ArrayList--");
            ArrayList arrayObj = new ArrayList();

            arrayObj.Add("string1");
            arrayObj.Add(234);
            arrayObj.Add(new object());
            arrayObj.Add("string2");
            arrayObj.Add(23.4);
            arrayObj.Add(new object());
            arrayObj.Add("string3");

            foreach (var element in arrayObj.GetExpandedIterator((x,y) => (x % 2 == 0) && (y is string)))
            {
                Console.WriteLine(element);
            }
        }
    }
}
