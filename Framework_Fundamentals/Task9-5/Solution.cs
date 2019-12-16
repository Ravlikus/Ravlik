using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9_5
{
    public class Solution
    {
        public static string ReverseAllWords(string input)
        {
            return input.Split(' ').Reverse().Aggregate((x,y) => x+" "+y);
        }
    }
}
