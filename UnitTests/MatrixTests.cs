using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Logic.Task1;
using System.Diagnostics;

namespace UnitTests
{
    [TestFixture]
    public class MatrixTests
    {
        SquareMatrix<int> firstSquare = new SquareMatrix<int>(new int[3][] { new int[3] { 1, 2, 3 }, new int[3] { 2, 3, 4 }, new int[3] { 3, 4, 5 } });
        SquareMatrix<int> firstSymmetric = new SymmetricalMatrix<int>(new int[3][] { new int[3] { 1, 2, 3 }, new int[3] { 2, 3, 4 }, new int[3] { 3, 4, 5 } });
        DiagonalMatrix<int> firstDiagonal = new DiagonalMatrix<int>(new int[3][] { new int[3] { 1, 0, 0 }, new int[3] { 0, 3, 0 }, new int[3] { 0, 0, 5 } });

        [Test]
        public void SumSquareAndSymmetricMatrix()
        {
            SquareMatrix<int> actual = firstSquare + firstSymmetric;
            int[][] expected = new int[3][] { new int[3] { 2, 4, 6 }, new int[3] { 4, 6, 8 }, new int[3] { 6, 8, 10 } };
            AssertMethod(expected, actual);
        }

        [Test]
        public void SumSymmetricAndDiagonal()
        {
            SquareMatrix<int> actual = firstSymmetric + firstDiagonal;
            int[][] expected = new int[3][] { new int[3] { 2, 2, 3 }, new int[3] { 2, 6, 4 }, new int[3] { 3, 4, 10 } };
            AssertMethod(expected, actual);
        }

        [Test]
        public void SumAllTypes()
        {
            SquareMatrix<int> actual = (firstSymmetric + firstSymmetric)
                + (firstSymmetric + firstDiagonal)
                + (firstSquare + firstSymmetric)
                + (firstSquare + firstDiagonal);
            int[][] expected = new int[3][] { new int[3] { 8, 12, 18 }, new int[3] { 12, 24, 24 }, new int[3] { 18, 24, 40 } };
            AssertMethod(expected, actual);
        }

        public void AssertMethod(int[][] expected, SquareMatrix<int> actual)
        {
            for (int i = 0; i < actual.Length; i++)
                for (int j = 0; j < actual.Length; j++)
                    Assert.AreEqual(expected[i][j], actual[i, j]);
        }
    }
}
