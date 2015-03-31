using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericMatrix;

namespace MatrixUI
{
    class Program
    {
        const int size = 5;

        static void Main(string[] args)
        {

            #region create and initialize sMatrix= SquareMatrix<object>
            SquareMatrix<object> sMatrix = new SquareMatrix<object>(size);
            sMatrix.changed += (object o, int i, int j) => Console.WriteLine("a[" + i + "," + j + "] = " + ((AbstractMatrix<object>)o)[i, j]);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    sMatrix[i, j] = (i + 1) * 5.3 + j;
                }
            sMatrix[3, 4] = "asdfasdf";
            #endregion
            SumMatrix(sMatrix, sMatrix, "--=Sum of sMatrix=--");

            Console.WriteLine();
            Console.WriteLine("Symmetric matrix initialize");
            #region create and initialize symMatrix= SymmetricMatrix<string>
            SymmetricMatrix<string> symMatrix = new SymmetricMatrix<string>(size);
            symMatrix.changed += (object o, int i, int j) =>
            {
                Console.WriteLine("a[" + i + "," + j + "] = " + ((AbstractMatrix<string>)o)[i, j]);
                if (i != j) Console.WriteLine("a[" + j + "," + i + "] = " + ((AbstractMatrix<string>)o)[j, i]);
            };
            for (int i = 0; i < size; i++)
                for (int j = 0; j <= i; j++)
                {
                    symMatrix[i, j] = "8" + i + j;
                }
            #endregion

            ShowMatrix(symMatrix, "Symmetric matrix");
            ShowMatrix(sMatrix, "Square matrix");
            SumMatrix(sMatrix, symMatrix, "--=Sum of sMatrix and symMatrix=--");

            Console.WriteLine();
            Console.WriteLine("Diagonal matrix initialize");
            #region create and initialize dmatrix= DiagonalMatrix<List<object>>
            DiagonalMatrix<List<object>> dMatrix = new DiagonalMatrix<List<object>>(size);
            symMatrix.changed += (object o, int i, int j) =>
            {
                Console.WriteLine("a[" + i + "," + j + "] = " + ((AbstractMatrix<List<object>>)o)[i, j]);
                if (i != j) Console.WriteLine("a[" + j + "," + i + "] = " + ((AbstractMatrix<List<object>>)o)[j, i]);
            };
            for (int i = 0; i < size; i++)
            {
                dMatrix[i, i] = new List<object>() { '8', i, i * i };
            }
            #endregion


            SumMatrix(symMatrix, dMatrix, "--=Sum of symMatrix and dMatrix=--");
            #region exeptions
            try
            {
                SumMatrix(dMatrix, symMatrix, "--=Sum of symMatrix and dMatrix=--"); //exeption
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            try
            {
                SumMatrix(sMatrix, dMatrix, "--=Sum of sMatrix and dMatrix=--"); //exeption
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            #endregion

            Console.WriteLine();
            Console.WriteLine("Double and int matrix initialize");
            #region create and initialize a= SquareMatrix<double>
            SquareMatrix<double> a = new SquareMatrix<double>(size);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    a[i, j] = (i + 1) * 5.3 + j;
                }
            #endregion

            #region create and initialize b= SquareMatrix<int>
            SquareMatrix<int> b = new SquareMatrix<int>(size);
            for (int i = 0; i < size; i++)
                for (int j = 0; j < size; j++)
                {
                    b[i, j] = (i + 1) + j;
                }
            #endregion

            SumMatrix(a, b, "--=Sum of a and b=--");
            try
            {
                SumMatrix(b, a, "--=Sum of a and b=--"); //exeption
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void SumMatrix<T,U>(AbstractMatrix<T> a, AbstractMatrix<U> b, string message)
        {
            AbstractMatrix<T> result = a.Sum(b);

            ShowMatrix(result, message);
        }

        private static void ShowMatrix<T>(AbstractMatrix<T> a, string message)
        {
            Console.WriteLine(message);

            for (int i = 0; i < a.Size; i++)
            {
                for (int j = 0; j < a.Size; j++)
                {
                    Console.Write(a[i, j] + "\t");
                }
                Console.WriteLine();
            }
        }
    }
}
