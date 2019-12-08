using System;
using System.Text;

namespace MethodsSol
{
    public static class DoubleExtentions
    {
        //Чет решение немного затянулось (тут всё ещё много костылей, но стандартные тесты вродь проходят)

        private static int manticeLenght = 52;
        private static int expLenght = 11;

        public static string ToBinaryString(this Double value)
        {
            if (value == double.PositiveInfinity) return "Positive Infinity";
            if (value == double.NegativeInfinity) return "Negative Infinity";
            //var result = value>0?"0":"1";
            var sign = value >= 0 ? "0" : "1";
            int exp;
            var normilizedValue = (decimal)GetExp(value,  out exp);
            var floatPart = normilizedValue<1?normilizedValue*2:(normilizedValue-1)*2;
            var mantice = new StringBuilder(manticeLenght);
            var flag = false;
            for (int i = 0; i < manticeLenght; i++)
            {
                if (floatPart > 1)
                {
                    mantice.Append(1);
                    floatPart -= 1;
                    flag = true;
                }
                else
                {
                    if (!flag && i == manticeLenght - 1)
                        mantice.Append(1);
                    else mantice.Append(0);
                }

                floatPart *= 2;
            }
            exp += (int)Math.Pow(2,expLenght-1) -1;
            var strExp = new StringBuilder(expLenght);

            var counter = 0;
            while (exp > 1 || counter < expLenght)
            {
                if (exp % 2 > 0) strExp.Insert(0,1);
                else strExp.Insert(0,0);
                exp /= 2;
                if (counter >= expLenght) throw new ArithmeticException("Exp is out of range");
                counter++;
            }
            return sign + strExp.ToString() + mantice.ToString();
        }

        private static double GetExp(double value,  out int exp)
        {
            value = Math.Abs(value);
            exp = 0;
            while (value >= 2 || value < 1)
            {
                if (value >= 2)
                {
                    exp++;
                    value /= 2;
                }
                else
                {
                    exp--;
                    value *= 2;
                }
            }

            return value;
        }
    }
}
