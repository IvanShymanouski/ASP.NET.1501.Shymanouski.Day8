using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FibonacciMethods
{
    public static class FibonacciClass
    {
        public static IEnumerable<Int64> Fibonacci(int count)
        {

            if (count < 0)
            {
                throw new ArgumentException("should not be a negative number");
            }

            Int64 f1=0;
            Int64 f2=1;
            int number=1;
            bool overflow = false;
            
            while(number++<count)
            {
                yield return f1;

                if (overflow) throw new OverflowException(string.Format("{0}", number));
                
                swap(ref f1, ref f2);

                try
                {
                    f2 = checked(f1 + f2);
                }
                catch
                {
                    overflow = true;
                }
            }
            if (count>0) yield return f1;
        }

        private static void swap(ref Int64 a, ref Int64 b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
        }
    }
}
