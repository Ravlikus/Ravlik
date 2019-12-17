using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Task11_2
{
    [TestFixture]
    public class Tests
    {
        static int[][] MatrixExample = new int[][] { new int[] { 1, 2, 3 }, new int[] { 2, 3, 4 }, new int[] { 3, 4, 5 } };

        [TestCase(Solution.SortByParam.ByMaxValue, Solution.OrderByParam.Ascending, ExpectedResult = true)]
        [TestCase(Solution.SortByParam.ByMaxValue, Solution.OrderByParam.Descending, ExpectedResult = true)]
        [TestCase(Solution.SortByParam.ByMinValue, Solution.OrderByParam.Ascending, ExpectedResult = true)]
        [TestCase(Solution.SortByParam.ByMinValue, Solution.OrderByParam.Descending, ExpectedResult = true)]
        [TestCase(Solution.SortByParam.BySum, Solution.OrderByParam.Ascending, ExpectedResult = true)]
        [TestCase(Solution.SortByParam.BySum, Solution.OrderByParam.Descending, ExpectedResult = true)]
        public bool SimpleSortTests(Solution.SortByParam sortBy, Solution.OrderByParam orderBy)
        {
            var matrix = MatrixExample;
            matrix = Solution.SortMatrix(matrix, sortBy, orderBy);
            switch (sortBy)
            {
                case Solution.SortByParam.ByMaxValue:
                    if (orderBy == Solution.OrderByParam.Ascending)
                        return CompareMatrix(matrix, MatrixExample.OrderBy(x => x.Max()).ToArray());
                    else return CompareMatrix(matrix, MatrixExample.OrderByDescending(x => x.Max()).ToArray());
                case Solution.SortByParam.ByMinValue:
                    if (orderBy == Solution.OrderByParam.Ascending)
                        return CompareMatrix(matrix, MatrixExample.OrderBy(x => x.Min()).ToArray());
                    else return CompareMatrix(matrix, MatrixExample.OrderByDescending(x => x.Min()).ToArray());
                case Solution.SortByParam.BySum:
                    if (orderBy == Solution.OrderByParam.Ascending)
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
