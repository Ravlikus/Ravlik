using System;
using System.Linq;
using System.Text;

namespace Task9_2
{
    public class Solution
    {
        /// <summary>
        /// Вывести строку в формате TitleCAse
        /// </summary>
        /// <param name="exceptions"> Строка, содержащая слова, на которые не распространяются правила TitleCase через пробел</param>
        /// <param name="text"> Строка, по отношению к которой применяется формат </param>
        /// <returns></returns>
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

         /// <summary>
         /// Капитализация слова
         /// </summary>
         /// <param name="word"> Cлово, по отношению к которому применяется капитализация </param>
         /// <returns></returns>
        public static string CapitilizeWord(string word)
        {
            return char.ToUpper(word[0]) + word.Substring(1).ToLower();
        }
    }
}
