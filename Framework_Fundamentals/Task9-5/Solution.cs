using System.Linq;

namespace Task9_5
{
    public class Solution
    {
        /// <summary>
        /// Возвращает исходную строку в обратном порядке
        /// </summary>
        /// <param name="input"> Исходная строка</param>
        /// <returns></returns>
        public static string ReverseAllWords(string input)
        {
            return input.Split(' ').Reverse().Aggregate((x,y) => x+" "+y);
        }
    }
}
