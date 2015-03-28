using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BinarySearchLibrary
{
    public static class BinarySearchClass
    {
        public static int BinarySearch<T>(this T[] mas, T item, Func<T,T,int> comparer)
        {
            if (object.Equals(comparer, null))
                throw new ArgumentNullException("comparer must be not null");

            int left = 0;
            int right = mas.Length - 1;
            int middle = (right + left) / 2;
            while (right >= left)
            {
                if (comparer(mas[middle],item)<0)
                {
                    if (right - left < 2) return -1;
                    left = middle;
                    middle = (right + left) / 2;
                }
                else if (comparer(mas[middle],item)>0)
                {
                    if (right - left < 2) return -1;
                    right = middle;
                    middle = (right + left) / 2;
                }
                else
                {
                    return middle;
                }
            }

            return -1;
        }
    }
}
