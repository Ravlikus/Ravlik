using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Task8_1
{
    public static class BubbleSortSolution
    {
        public enum SortByParam
        {
            BySum,
            ByMaxValue,
            ByMinValue
        }

        public enum OrderByParam
        {
            Ascending,
            Descending
        }

        /// <summary>
        /// Метод сортировки двумерной матрицы
        /// </summary>
        /// <param name="matrix">Матрица</param>
        /// <param name="sortBy">Парамметр сортировки (по сумме строки,максимальному/минимальному значению в строке)</param>
        /// <param name="orderBy">Парамметр результирующего порядка(по возрастанию/убыванию)</param>
        public static int[][] SortMatrix(int[][] matrix, SortByParam sortBy, OrderByParam orderBy)
        {
            var matrixRowsData = new RowData[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                var rowData = new RowData();
                rowData.NumberByOrder = i;
                switch (sortBy)
                {
                    case SortByParam.ByMaxValue:
                        rowData.SortValue = matrix[i].Max();
                        break;
                    case SortByParam.ByMinValue:
                        rowData.SortValue = matrix[i].Min();
                        break;
                    case SortByParam.BySum:
                        rowData.SortValue = matrix[i].Sum();
                        break;
                }

                matrixRowsData[i] = rowData;
            }

            for (int i = 1; i < matrixRowsData.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (orderBy == OrderByParam.Ascending)
                        if (matrixRowsData[j].SortValue < matrixRowsData[j - 1].SortValue)
                        {
                            var container = matrixRowsData[j];
                            matrixRowsData[j] = matrixRowsData[j - 1];
                            matrixRowsData[j - 1] = container;
                        }
                    if (orderBy == OrderByParam.Descending)
                        if (matrixRowsData[j].SortValue > matrixRowsData[j - 1].SortValue)
                        {
                            var container = matrixRowsData[j];
                            matrixRowsData[j] = matrixRowsData[j - 1];
                            matrixRowsData[j - 1] = container;
                        }
                }
            }

            var result = new int[matrix.Length][];
            for (int i = 0; i < matrix.Length; i++)
            {
                result[i] = matrix[matrixRowsData[i].NumberByOrder];
            }

            return result;
        }

        private class RowData
        {
            public int NumberByOrder;
            public int SortValue;
        }
    }

    [TestFixture]
    public class BubbleSortTests
    {
        static int[][] MatrixExample = new int[][] { new int[] { 1, 2, 3 }, new int[] { 2, 3, 4 }, new int[] { 3, 4, 5 } };

        [TestCase(BubbleSortSolution.SortByParam.ByMaxValue, BubbleSortSolution.OrderByParam.Ascending, ExpectedResult = true)]
        [TestCase(BubbleSortSolution.SortByParam.ByMaxValue, BubbleSortSolution.OrderByParam.Descending, ExpectedResult = true)]
        [TestCase(BubbleSortSolution.SortByParam.ByMinValue, BubbleSortSolution.OrderByParam.Ascending, ExpectedResult = true)]
        [TestCase(BubbleSortSolution.SortByParam.ByMinValue, BubbleSortSolution.OrderByParam.Descending, ExpectedResult = true)]
        [TestCase(BubbleSortSolution.SortByParam.BySum, BubbleSortSolution.OrderByParam.Ascending, ExpectedResult = true)]
        [TestCase(BubbleSortSolution.SortByParam.BySum, BubbleSortSolution.OrderByParam.Descending, ExpectedResult = true)]
        public bool SimpleSortTests(BubbleSortSolution.SortByParam sortBy, BubbleSortSolution.OrderByParam orderBy)
        {
            var matrix = MatrixExample;
            matrix = BubbleSortSolution.SortMatrix(matrix, sortBy, orderBy);
            switch (sortBy)
            {
                case BubbleSortSolution.SortByParam.ByMaxValue:
                    if (orderBy == BubbleSortSolution.OrderByParam.Ascending)
                        return CompareMatrix(matrix, MatrixExample.OrderBy(x => x.Max()).ToArray());
                    else return CompareMatrix(matrix, MatrixExample.OrderByDescending(x => x.Max()).ToArray());
                case BubbleSortSolution.SortByParam.ByMinValue:
                    if (orderBy == BubbleSortSolution.OrderByParam.Ascending)
                        return CompareMatrix(matrix, MatrixExample.OrderBy(x => x.Min()).ToArray());
                    else return CompareMatrix(matrix, MatrixExample.OrderByDescending(x => x.Min()).ToArray());
                case BubbleSortSolution.SortByParam.BySum:
                    if (orderBy == BubbleSortSolution.OrderByParam.Ascending)
                        return CompareMatrix(matrix, MatrixExample.OrderBy(x => x.Sum()).ToArray());
                    else return CompareMatrix(matrix, MatrixExample.OrderByDescending(x => x.Sum()).ToArray());
                default: return false;
            }
        }

        private bool CompareMatrix(int[][] first, int[][] second)
        {
            var flag = true;
            for (int i = 0; i < first.Length; i++)
            {
                for (int j = 0; j < first[i].Length; j++)
                {
                    if (first[i][j] != second[i][j])
                    {
                        flag = false;
                        break;
                    }
                }
                if (!flag)
                    break;
            }

            return flag;
        }
    }
}
