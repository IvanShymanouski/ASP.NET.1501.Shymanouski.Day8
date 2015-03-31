using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CSharp.RuntimeBinder;

namespace GenericMatrix
{
    public static class MatrixOperation
    {
        /// <summary>
        /// addition of 2 matrix
        /// </summary>
        /// <returns>first matrix type or non DiagonalType if have</returns>
        public static dynamic Sum<T, U>(this AbstractMatrix<T> a, AbstractMatrix<U> b)
        {
            if (a.Size != b.Size) throw new ArgumentException("Matrix must be same size");

            dynamic aMatrix = a;
            dynamic bMatrix = b;

            return AddMatrix(aMatrix, bMatrix);
        }

        private static SquareMatrix<U> AddMatrix<T, U>(DiagonalMatrix<T> a, AbstractMatrix<U> b)
        {
            return AddMatrix(b, a);
        }

        private static SquareMatrix<U> AddMatrix<T, U>(AbstractMatrix<U> a, DiagonalMatrix<T> b)
        {
            SquareMatrix<U> result = new SquareMatrix<U>(a.Size);

            for (int i = 0; i < a.Size; i++)
                for (int j = 0; j < a.Size; j++)
                {
                    if (i == j)
                    {
                        dynamic ai = a[i, i];
                        dynamic bi = b[i, i];
                        try
                        {
                            result[i, i] = ai + bi;
                        }
                        catch (RuntimeBinderException ex)
                        {
                            throw new ArgumentException("Arguments can't be added i=" + i + ",j=" + j + ":" + a[i, j].ToString() + " and " + b[i, j].ToString());
                        }
                        catch (Exception ex)
                        {
                            throw new InvalidOperationException("", ex);
                        }
                    }
                    else
                        result[i, j] = a[i, j];
                }
            return result;
        }

        private static SquareMatrix<T> AddMatrix<T, U>(AbstractMatrix<T> a, AbstractMatrix<U> b)
        {
            SquareMatrix<T> result = new SquareMatrix<T>(a.Size);
            for (int i = 0; i < a.Size; i++)
                for (int j = 0; j < a.Size; j++)
                {
                    dynamic aij = a[i, j];
                    dynamic bij = b[i, j];
                    try
                    {
                        result[i, j] = aij + bij;
                    }
                    catch (RuntimeBinderException ex)
                    {
                        throw new ArgumentException("Arguments can't be added i=" + i + ",j=" + j + ":" + a[i, j].ToString() + " and " + b[i, j].ToString());
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("",ex);
                    }
                }
            return result;
        }
    }
}
