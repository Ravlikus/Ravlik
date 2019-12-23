using System.Text;

namespace Task9_6
{
    public class Solution
    {
        /// <summary>
        /// Складывает числа в строковом представлении
        /// </summary>
        /// <param name="a"> Число 1</param>
        /// <param name="b"> Число 2</param>
        /// <returns></returns>
        public static string AddBigNumbers(string a, string b)
        {
            var biggerNum = a.Length >= b.Length ? a : b;
            var lesserNum = a.Length < b.Length ? a : b;

            var result = new StringBuilder(biggerNum.Length+1);
            int cache = 0;
            for(int i = 0; i<biggerNum.Length || cache>0; i++)
            {
                var num = cache;
                if (i < biggerNum.Length) num += int.Parse(biggerNum.Substring(biggerNum.Length - i - 1, 1)) ;
                if (i<lesserNum.Length) num += int.Parse(lesserNum.Substring(lesserNum.Length - i - 1, 1));
                result.Insert(0,num % 10 );
                cache = num / 10;
            }

            return result.ToString();
        }
    }
}
