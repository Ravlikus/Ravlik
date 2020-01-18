using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_3
{
    public class Solution
    {
        public static IEnumerable<int> GetFibbonacciNumbers(int count)
        {
            var N0 = 1;
            yield return N0;
            var N1 = 1;
            yield return N1;
            count -= 2;
            while(count>0)
            {
                var result = N0 + N1;
                yield return result;
                N0 = N1;
                N1 = result;
            }
            yield break;
        }
    }
}
