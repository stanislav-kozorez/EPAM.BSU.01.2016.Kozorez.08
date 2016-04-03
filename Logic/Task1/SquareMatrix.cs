using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Task1
{
    public class SquareMatrix<T> where T : IEquatable<T>
    {
        protected T[][] matrix;

        public event EventHandler<ElementChangedArgs> OnElementChanged = delegate { };

        public virtual T this[int i, int j]
        {
            get
            {
                if (i < 0 || i > matrix.Length || j < 0 || j > matrix.Length)
                    throw new IndexOutOfRangeException("Out of range");
                return matrix[i][j];
            }
            set
            {
                if (i < 0 || i > matrix.Length || j < 0 || j > matrix.Length)
                    throw new IndexOutOfRangeException("Out of range");
                matrix[i][j] = value;
                ElementChangedArgs args = new ElementChangedArgs(i, j);
                ElementChanged(args);
            }
        }

        public SquareMatrix(T[][] matrix)
        {
            if (matrix == null)
                new ArgumentNullException(nameof(matrix));

            for (int i = 0; i < matrix.Length; i++)
            {
                if (matrix[i] == null)
                    new ArgumentNullException("Null row");
                if (matrix[i].Length != matrix.Length)
                    new ArgumentException("Matrix length");
            }
            this.matrix = matrix;
        }

        //public static SquareMatrix<int> operator +(SquareMatrix<int> first, SquareMatrix<int> second)
        //{
        //    int[][] result;

        //    if (first.matrix.Length != second.matrix.Length)
        //        throw new ArgumentException("Incompatible length");

        //    result = new int[first.matrix.Length][];

        //    for (int i = 0; i < result.Length; i++)
        //        result[i] = new int[result.Length];

        //    for (int i = 0; i < first.matrix.Length; i++)
        //        for (int j = 0; i < first.matrix.Length; j++)
        //        {
        //            result[i][j] = first[i, j] + second[i, j];
        //        }

        //    return new SquareMatrix<int>(result);
        //}

        protected void ElementChanged(ElementChangedArgs args)
        {
            EventHandler<ElementChangedArgs> handler = OnElementChanged;
            handler?.Invoke(this, args);
        }

    }

    public class ElementChangedArgs: EventArgs
    {
        private int i;
        private int j;

        public int I { get { return i; } }
        public int J { get { return j; } }
        public ElementChangedArgs(int i, int j)
        {
            this.i = i;
            this.j = j;
        }
    }
}
