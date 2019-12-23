using System.Collections.Generic;
using System.Linq;

namespace Task11_2
{
    public class Solution
    {
        private delegate RowData[] OrderCriterionMethodType(RowData[] data);
        private delegate RowData[] SortCriterionMethodType(int[][] matrix);
        public delegate int[][] MatrixSorter(int[][] matrix, SortByParam sortBy, OrderByParam orderBy);
        public static MatrixSorter SortMatrix = Sort;


        private static int[][] Sort(int[][] matrix, SortByParam sortBy, OrderByParam orderBy)
        {
            var resultRows = OrderMethods[orderBy](SortMethods[sortBy](matrix));
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
                { SortByParam.ByMaxValue, SortByMax },
                { SortByParam.ByMinValue, SortByMin },
                { SortByParam.BySum, SortBySum },
            };

        private static RowData[] SortByMax(int[][] matrix)
        {
            var matrixRowsData = new RowData[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                var rowData = new RowData();
                rowData.NumberByOrder = i;
                rowData.SortValue = matrix[i].Max();
                matrixRowsData[i] = rowData;
            }
            return matrixRowsData;
        }

        private static RowData[] SortByMin(int[][] matrix)
        {
            var matrixRowsData = new RowData[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                var rowData = new RowData();
                rowData.NumberByOrder = i;
                rowData.SortValue = matrix[i].Min();
                matrixRowsData[i] = rowData;
            }
            return matrixRowsData;
        }
        private static RowData[] SortBySum(int[][] matrix)
        {
            var matrixRowsData = new RowData[matrix.Length];
            for (int i = 0; i < matrix.Length; i++)
            {
                var rowData = new RowData();
                rowData.NumberByOrder = i;
                rowData.SortValue = matrix[i].Sum();
                matrixRowsData[i] = rowData;
            }
            return matrixRowsData;
        }

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
