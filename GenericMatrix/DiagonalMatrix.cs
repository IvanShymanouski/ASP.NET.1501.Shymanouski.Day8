﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericMatrix
{
    public sealed class DiagonalMatrix<T> : AbstractSquareMatrix<T>
    {
        public DiagonalMatrix(int size) : base(size) 
        {
            matrix = new T[size];
        }

        protected override T getValue(int i, int j)
        {
            if (i == j) return matrix[i];
            else return default(T);
        }

        protected override void setValue(int i, int j, T value)
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
