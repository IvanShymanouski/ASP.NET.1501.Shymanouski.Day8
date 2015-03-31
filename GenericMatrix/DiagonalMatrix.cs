using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public sealed class DiagonalMatrix<T> : AbstractMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size) 
        {
            matrix = new T[size];
        }

        protected override T GetValue(int i, int j)
        {
            if (i == j) return matrix[i];
            else return default(T);
        }

        protected override void SetValue(int i, int j, T value)
        {
            if (i != j)
            {
                throw new ArgumentException("i must be equal j");
            }
            else
            {
                matrix[i] = value;
            }
        } 
    }
}
