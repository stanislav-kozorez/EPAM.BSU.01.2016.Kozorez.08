using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Task1
{
    public class DiagonalMatrix<T>: SquareMatrix<T> where T :IEquatable<T>
    {
        private T[] matrix;
        public override T this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);
                if (i == j)
                    return matrix[i];
                else
                    return default(T);
            }
            set
            {
                CheckIndexes(i, j);
                if (i != j && !value.Equals(default(T)))
                    throw new ArgumentException("Wrong value");
                else
                    matrix[i] = value;
                ElementChangedArgs args = new ElementChangedArgs(i, j);
                ElementChanged(args);
            }
        }

        public DiagonalMatrix(T[][] matrix)
            : base(matrix)
        {
            this.matrix = new T[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
                this.matrix[i] = matrix[i][i];
        }
    }
}
