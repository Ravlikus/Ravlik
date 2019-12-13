using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9_2
{
    public class Solution
    {
        public static string ToTitleCase(string exceptions, string text)
        {
            var splitedText = text.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            if (splitedText.Length == 0) return "";
            var excepts = exceptions.ToLower().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var result = new StringBuilder();
            result.Append(CapitilizeWord(splitedText[0]));
            for (int i = 1; i<splitedText.Length; i++)
            {
                result.Append(" ");
                if (!excepts.Contains(splitedText[i])) result.Append(CapitilizeWord(splitedText[i]));
                else result.Append(splitedText[i]);
            }
            return result.ToString();
        }

        public static string CapitilizeWord(string word)
        {
            return char.ToUpper(word[0]) + word.Substring(1);
        }
    }
}
