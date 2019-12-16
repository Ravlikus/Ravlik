using System.Linq;

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

    
}
