using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Task1
{
    public class SymmetricalMatrix<T>: SquareMatrix<T> where T: IEquatable<T>
    {
        public override T this[int i, int j]
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

        public SymmetricalMatrix(T[][] matrix)
            :base(matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
                for (int j = 0; i < matrix.Length; j++)
                    if (!matrix[i][j].Equals(matrix[j][i]))
                        throw new ArgumentException(nameof(matrix));
        }
    }
}
