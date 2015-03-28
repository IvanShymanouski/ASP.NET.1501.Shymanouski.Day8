using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public static class MatrixOperation
    {
        public static SquareMatrix<T> Sum<T,U>(this AbstractSquareMatrix<T> a, AbstractSquareMatrix<U> b)
        {
            if (a.Size != b.Size) throw new ArgumentException("Matrix must be same size");
            SquareMatrix<T> result = new SquareMatrix<T>(a.Size);

            for(int i=0; i<a.Size; i++)
                for (int j = 0; j < a.Size; j++)
                {
                    dynamic aij = a[i, j];
                    dynamic bij = b[i, j];
                    try
                    {
                        result[i, j] = aij + bij;
                    }
                    catch
                    {                        
                        throw new ArgumentException("Arguments can't be added i=" + i + ",j=" + j + ":" + a[i, j].ToString() + " and " + b[i, j].ToString());
                    }
                }

            return result;
        }
    }
}
