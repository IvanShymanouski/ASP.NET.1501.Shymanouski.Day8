using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public sealed class SquareMatrix<T> : AbstractMatrix<T>
    {

        public SquareMatrix(int size) : base(size) 
        {
            matrix = new T[size * size];
        }

        protected override T GetValue(int i, int j)
        {
            return matrix[i + j * (Size - 1)];
        }

        protected override void SetValue(int i, int j, T value)
        {
            matrix[i + j * (Size - 1)] = value;
        }
    }
}
