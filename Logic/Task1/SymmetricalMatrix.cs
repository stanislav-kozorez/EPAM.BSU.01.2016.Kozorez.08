using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Task1
{
    public class SymmetricalMatrix<T>: SquareMatrix<T> where T: IEquatable<T>
    {
        private T[][] matrix;

        public override T this[int i, int j]
        {
            get
            {
                CheckIndexes(i, j);
                if (i >= j)
                    return matrix[i][j];
                else
                    return matrix[j][i];
            }
            set
            {
                CheckIndexes(i, j);
                if (i <= j)
                    matrix[i][j] = value;
                else
                    matrix[j][i] = value;
                ElementChangedArgs args = new ElementChangedArgs(i, j);
                ElementChanged(args);
            }
        }

        public SymmetricalMatrix(T[][] matrix)
            :base(matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; j < matrix.Length; j++)
                    if (!matrix[i][j].Equals(matrix[j][i]))
                        throw new ArgumentException(nameof(matrix));
            this.matrix = new T[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                this.matrix[i] = new T[i + 1];
                for (int j = 0; j <= i; j++)
                {
                    this.matrix[i][j] = matrix[i][j];
                }
            }
        }
    }
}
