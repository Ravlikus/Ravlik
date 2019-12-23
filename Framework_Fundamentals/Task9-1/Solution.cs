using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task9_1
{
    public class Person
    {
        public string Name;
        public string PhoneNumber;
        public decimal Revenue;

        public override string ToString()
        {
            return $"{Name}, {Revenue}, {PhoneNumber}";
        }

        /// <summary>
        /// Возвращает строку, сформированную по заданному формату
        /// </summary>
        /// <param name="outFormat"> Строка, определяющая порядок данных, и разделители между ними ("p,n:r" => "{PhoneNumber},{Name}:{Revenue}")</param>
        /// <param name="numberFormat"> Строка, по которой будет сформирован номер ("nn(nnn)-nn-nn" => "12(345)-67-89")</param>
        /// <param name="culture"> Формат вывода (по нему выводится Revenue)</param>
        /// <returns></returns>
        public string ToString(string outFormat, string numberFormat, CultureInfo culture)
        {
            var lastCulture = CultureInfo.CurrentCulture;
            var numberSB = new StringBuilder(numberFormat.Length);
            for (int i = 0, j = 0 ; i<numberFormat.Length; i++)
            {
                if (numberFormat.ToLower()[i] == 'p')
                {
                    numberSB.Append(PhoneNumber[j]);
                    j++;
                }
                else
                    numberSB.Append(numberFormat[i]);
            }
            CultureInfo.CurrentCulture = culture;
            var outSB = new StringBuilder();
            var flag = false;
            for (int i = 0; i<outFormat.Length;i++)
            {
                if (outFormat[i] == '{') flag = true;
                else if (outFormat[i] == '}') flag = false;
                else if (flag)
                {
                    if (outFormat.ToLower()[i] == 'n') outSB.Append(Name);
                    else if (outFormat.ToLower()[i] == 'p') outSB.Append(numberSB.ToString());
                    else if (outFormat.ToLower()[i] == 'r') outSB.Append(Revenue.ToString("C"));
                }
               else outSB.Append(outFormat[i]);
            }
            var result = outSB.ToString();
            CultureInfo.CurrentCulture = lastCulture;
            return result;
        }
    }
}
