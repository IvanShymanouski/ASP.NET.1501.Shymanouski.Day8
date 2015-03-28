using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public delegate void MatrixEventHandler(object o, int i, int j);

    abstract public class AbstractSquareMatrix<T>
    {
        public event MatrixEventHandler changed;

        protected T[,] matrix;

        public T this[int i, int j]
        {
            get
            {
                if (i < Size && j < Size)
                {
                    return matrix[i, j];
                }
                else
                throw new IndexOutOfRangeException();
            }
            set
            {
                if (i < Size && j < Size)
                {
                    setValue(i, j,value);
                    changed(this, i, j);
                }
                else
                throw new IndexOutOfRangeException();
            }
        }
    
        public int Size { get; protected set; }

        public AbstractSquareMatrix(int size)
        {
            changed += delegate(object o, int i, int j) { };
            Size = size;
            matrix = new T[size, size];
        }

        protected abstract void setValue(int i,int j,T value);

    }
}
