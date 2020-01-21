using System.Collections.Generic;
using System.Linq;

namespace Task11_2
{
    public class Solution
    {
        public delegate int[][] MatrixSorter(int[][] matrix, SortByParam sortBy = SortByParam.BySum, OrderByParam orderBy = OrderByParam.Ascending);
        public static MatrixSorter SortMatrix = Sort;

        private delegate RowData[] OrderCriterionMethodType(RowData[] data);
        private delegate int SortCriterionMethodType(int[] matrix);


        private static int[][] Sort(int[][] matrix, SortByParam sortBy, OrderByParam orderBy)
        {
            var unorderedRowsData = new RowData[matrix.Length];

            for(int i = 0; i < unorderedRowsData.Length; i++)
            {
                unorderedRowsData[i] = new RowData(i, SortMethods[sortBy](matrix[i]));
            }

            var resultRows = OrderMethods[orderBy](unorderedRowsData);

            var result = new int[matrix.Length][];

            for (int i = 0; i < matrix.Length; i++)
            {
                result[i] = matrix[resultRows[i].NumberByOrder];
            }

            return result;
        }

        private static Dictionary<OrderByParam, OrderCriterionMethodType> OrderMethods =
            new Dictionary<OrderByParam, OrderCriterionMethodType>()
            {
                { OrderByParam.Ascending, OrderByAscending },
                { OrderByParam.Descending, OrderByDescending }
            };


        private static Dictionary<SortByParam, SortCriterionMethodType> SortMethods =
            new Dictionary<SortByParam, SortCriterionMethodType>()
            {
                { SortByParam.ByMaxValue, Max },
                { SortByParam.ByMinValue, Min },
                { SortByParam.BySum, Sum },
            };

        private static int Max(int[] data) => data.Max();
        private static int Min(int[] data) => data.Min();
        private static int Sum(int[] data) => data.Sum();

        private static RowData[] OrderByAscending(RowData[] data)
        {
            for (int i = 1; i < data.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (data[j].SortValue < data[j - 1].SortValue)
                    {
                        var container = data[j];
                        data[j] = data[j - 1];
                        data[j - 1] = container;
                    }
                }
            }
            return data;
        }

        private static RowData[] OrderByDescending(RowData[] data)
        {
            for (int i = 1; i < data.Length; i++)
            {
                for (int j = i; j > 0; j--)
                {
                    if (data[j].SortValue > data[j - 1].SortValue)
                    {
                        var container = data[j];
                        data[j] = data[j - 1];
                        data[j - 1] = container;
                    }
                }
            }
            return data;
        }

        private class RowData
        {
            public RowData(int num, int value)
            {
                NumberByOrder = num;
                SortValue = value;
            }

            public int NumberByOrder;
            public int SortValue;
        }

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
    }
}
