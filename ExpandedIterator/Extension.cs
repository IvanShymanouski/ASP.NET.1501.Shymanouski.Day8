using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpandedIterator
{
    public static class Extension
    {

        /// <summary>
        /// Extansion for generic collections
        /// </summary>
        /// <param name="getterRule">rule for getting elements</param>
        public static IEnumerable<T> GetExpandedIterator<T>(this IEnumerable<T> someColection, Func<int,T,bool> getterRule)
        {
            int i = -1;
            foreach (T element in someColection)
            {
                i++;
                if (getterRule(i, element)) yield return element;
            }
        }

        /// <summary>
        /// Extansion for collections
        /// </summary>
        /// <param name="getterRule">rule for getting elements</param>
        public static IEnumerable GetExpandedIterator(this IEnumerable someColection, Func<int, object, bool> getterRule)
        {
            int i = -1;
            foreach (var element in someColection)
            {
                i++;
                if (getterRule(i, element)) yield return element;
            }
        }

    }
}
