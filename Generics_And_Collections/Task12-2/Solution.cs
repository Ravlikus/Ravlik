using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_2
{
    public class Solution
    {
        static char[] wordDelimeteres = new char[] { ' ', ',', '.', '!', '?', ':', ';' };
        public static Dictionary<string,int> GetWordFrequency(string text)
        {
            var result = new Dictionary<string, int>();
            foreach(var word in text.Split(wordDelimeteres, StringSplitOptions.RemoveEmptyEntries))
            {
                if (result.ContainsKey(word.ToLower())) result[word.ToLower()]++;
                else result.Add(word.ToLower(), 1);
            }
            return result;
        }
    }
}
