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
