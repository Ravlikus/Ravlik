using System.Linq;
using NUnit.Framework;

namespace Task8_1
{
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
