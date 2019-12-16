using System.Linq;

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
