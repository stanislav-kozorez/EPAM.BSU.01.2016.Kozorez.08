using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Task1
{
    public class SquareMatrix<T>
    {
        private T[][] matrix;

        public event EventHandler<ElementChangedArgs> OnElementChanged = delegate { };
        public int Length { get { return matrix.Length; } }
        public virtual T this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);
                return matrix[i][j];
            }
            set
            {
                CheckIndexes(i, j);
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

        public static SquareMatrix<T> operator +(SquareMatrix<T> first, SquareMatrix<T> second)
        {
            T[][] result;

            if (first.matrix.Length != second.matrix.Length)
                throw new ArgumentException("Incompatible length");

            ParameterExpression p1 = Expression.Parameter(typeof(T), "first");
            ParameterExpression p2 = Expression.Parameter(typeof(T), "second");
            Expression add = Expression.Add(p1, p2);
            LambdaExpression lambda = Expression.Lambda(add, p1, p2);
            var Sum = (Func<T, T, T>)lambda.Compile();

            result = new T[first.matrix.Length][];

            for (int i = 0; i < result.Length; i++)
                result[i] = new T[result.Length];

            for (int i = 0; i < first.matrix.Length; i++)
                for (int j = 0; j < first.matrix.Length; j++)
                {
                    result[i][j] = Sum(first[i, j], second[i, j]);
                }

            return new SquareMatrix<T>(result);
        }

        protected void CheckIndexes(int i, int j)
        {
            if (i < 0 || i > matrix.Length || j < 0 || j > matrix.Length)
                throw new IndexOutOfRangeException("Out of range");
        }

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
