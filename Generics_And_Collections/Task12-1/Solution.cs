using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_1
{
    class Solution
    {
        public static int FindElement<T>(T[] data, T neededElement, Comparer<T> comparer)
        {
            if (data[0].Equals(neededElement)) return 0;
            var bottomBorder = 0;
            var topBorder = data.Length - 1;

            while (bottomBorder <= topBorder)
            {
                var middle = (topBorder + bottomBorder) / 2;
                if (comparer.Compare(data[middle], neededElement) == 0) return middle;
                else if (comparer.Compare(data[middle], neededElement) > 0) { topBorder = middle ; }
                else bottomBorder = middle + 1 ;
            }

            throw new Exception("Element not found!");
        }
    }
}
