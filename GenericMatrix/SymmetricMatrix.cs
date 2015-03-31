using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public sealed class SymmetricMatrix<T> : AbstractSquareMatrix<T>
    {
        public SymmetricMatrix(int size) : base(size) 
        {
            matrix = new T[size * (size + 1) / 2];
        }

        protected override T GetValue(int i, int j)
        {
            if (i < j) Swap(ref i, ref j);
            return matrix[i * (i + 1) / 2 + j];
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (i < j) Swap(ref i, ref j);
            matrix[i * (i + 1) / 2 + j] = value;
        }

        private static void Swap(ref int a, ref int b)
        {
            a = a ^ b;
            b = a ^ b;
            a = a ^ b;
        }
    }
}
