using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public sealed class SquareMatrix<T> : AbstractSquareMatrix<T>
    {
        public SquareMatrix(int size) : base(size) { }

        protected override void setValue(int i, int j, T value)
        {
            matrix[i, j] = value;
        }
    }
}
