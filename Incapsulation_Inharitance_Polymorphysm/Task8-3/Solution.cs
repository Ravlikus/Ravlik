using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Task8_3
{
    public class Polynom
    {
        public PolynomUnit[] PolynomUnits ;
        public Polynom MOD { get; private set; }

        public Polynom(params PolynomUnit[] units)
        {
            var contained = new HashSet<int>();
            foreach(var unit in units.Where(x=>x.Coefitient!=0))
            {
                if (contained.Contains(unit.Pow)) throw new ArgumentException("Some pows are duplicated in units");
                else contained.Add(unit.Pow);
            }
            PolynomUnits = units;
        }

        public Polynom(List<PolynomUnit> units)
        {
            var contained = new HashSet<int>();
            foreach (var unit in units.Where(x => x.Coefitient != 0))
            {
                if (contained.Contains(unit.Pow)) throw new ArgumentException("Some pows are duplicated in units");
                else contained.Add(unit.Pow);
            }
            PolynomUnits = units.ToArray();
        }

        /// <summary>
        /// Вычисляет значение полинома
        /// </summary>
        /// <param name="value">Исходное число</param>
        /// <returns>Результат вычисления полинома от исходного числа</returns>
        public double CountResult(double value)
        {
            var result = 0.0;
            foreach(var unit in PolynomUnits)
            {
                result += unit.Coefitient * Math.Pow(value, unit.Pow);
            }
            return result;
        }

        /// <summary>
        /// Определить степень полинома
        /// </summary>
        /// <returns>Степень полинома</returns>
        public int GetMaxPow()
        {
            if (PolynomUnits.Where(x=>x.Coefitient!=0).Count() == 0) return -1;
            return PolynomUnits.Where(x=>x.Coefitient!=0).Select(x => x.Pow).Max();
        }

        // Стандартная реализация, которую сгенерил вижак
        public override bool Equals(object obj)
        {
            return obj is Polynom polynom &&
                   EqualityComparer<PolynomUnit[]>.Default.Equals(PolynomUnits, polynom.PolynomUnits);
        }

        // Стандартная реализация, которую сгенерил вижак
        public override int GetHashCode()
        {
            return -119518562 + EqualityComparer<PolynomUnit[]>.Default.GetHashCode(PolynomUnits);
        }

        public override string ToString()
        {
            if (PolynomUnits.Length == 0) return "<empty>";
            var result = new StringBuilder();
            result.Append($"{PolynomUnits[0].Coefitient}x^{PolynomUnits[0].Pow}");
            for (int i = 1; i < PolynomUnits.Length; i++)
            {
                if (PolynomUnits[i].Coefitient >= 0) result.Append($"+{PolynomUnits[i].Coefitient}x^{PolynomUnits[i].Pow}");
                else result.Append($"{PolynomUnits[i].Coefitient}x^{PolynomUnits[i].Pow}");
            }

            return result.ToString();
        }

        private void DeleteZeroCoefUnits()
        {
            PolynomUnits = PolynomUnits.Where(x => x.Coefitient != 0).ToArray();
        }

        private void DeleteZeroCoefUnits(Polynom poly)
        {
            poly.PolynomUnits = poly.PolynomUnits.Where(x => x.Coefitient != 0).ToArray();
        }

        public static Polynom operator +(Polynom a, Polynom b)
        {
            var resultUnits = a.PolynomUnits.ToList();
            for(int j = 0; j < b.PolynomUnits.Length; j++)
            {
                var flag = false;
                for(int i = 0; i < a.PolynomUnits.Length; i++)
                {
                    if(a.PolynomUnits[i].Pow == b.PolynomUnits[j].Pow)
                    {
                        resultUnits[i] = new PolynomUnit(a.PolynomUnits[i].Coefitient + b.PolynomUnits[j].Coefitient, a.PolynomUnits[i].Pow);
                        flag = true;
                        break;
                    }
                }
                if (!flag)
                {
                    resultUnits.Add(b.PolynomUnits[j]);
                }
            }
            return new Polynom(resultUnits);

        }

        public static Polynom operator -(Polynom a, Polynom b)
        {
            var negativeB = new Polynom(b.PolynomUnits.Select(x => new PolynomUnit(-x.Coefitient,x.Pow)).ToArray());
            return a + negativeB;
        }

        public static Polynom operator *(Polynom a, Polynom b)
        {
            var result = new Polynom();
            for(int i = 0; i < a.PolynomUnits.Length; i++)
            {
                for(int j = 0; j < b.PolynomUnits.Length; j++)
                {
                    // По факту создаётся полином, к которому приавляются все комбинации членов входных полиномов
                    result += new Polynom( new PolynomUnit(a.PolynomUnits[i].Coefitient * b.PolynomUnits[j].Coefitient, a.PolynomUnits[i].Pow + b.PolynomUnits[j].Pow) );
                }
            }
            return result;
        }

        public static Polynom operator /(Polynom divisible, Polynom divisor)
        {
            var result = new List<PolynomUnit>();
            var maxDivisorPow = divisor.PolynomUnits.Select(x => x.Pow).Max();
            divisible.MOD = new Polynom(divisible.PolynomUnits);
            while(divisible.MOD.GetMaxPow()>=maxDivisorPow)
            {
                var currentPoly = new PolynomUnit(divisible.MOD.PolynomUnits
                    .Where(x => x.Pow == divisible.MOD.GetMaxPow())
                    .Select(x => x.Coefitient)
                    .First() /
                    divisor.PolynomUnits
                    .Where(x => x.Pow == divisor.GetMaxPow())
                    .Select(x => x.Coefitient)
                    .First()
                    , divisible.MOD.GetMaxPow() - maxDivisorPow);
                result.Add(currentPoly);
                divisible.MOD -= new Polynom(currentPoly) * divisor;
            }
            return new Polynom(result);
        }

        public static bool operator ==(Polynom a, Polynom b)
        {
            var aFlag = a is null || a.PolynomUnits.Where(x => x.Coefitient != 0).Count() == 0;
            var bFlag = b is null || b.PolynomUnits.Where(x => x.Coefitient != 0).Count() == 0;
            if (aFlag && bFlag) return true;
            if (aFlag || bFlag) return false;
            if (a.MOD != b.MOD) return false;
            if (a.PolynomUnits.Where(x=>x.Coefitient!=0).Count() != b.PolynomUnits.Where(x => x.Coefitient != 0).Count()) return false;
            for (int i = 0; i < a.PolynomUnits.Length; i++)
            {
                var flag = a.PolynomUnits[i].Coefitient == 0;
                for(int j = 0; j < b.PolynomUnits.Length; j++)
                {
                    if (a.PolynomUnits[i] == b.PolynomUnits[j])
                    {
                        flag = true;
                    }
                    if (flag) break;
                }
                if (!flag) return false;
            }
            return true;
        }

        public static bool operator !=(Polynom a, Polynom b)
        {
            return !(a == b);
        }
    }
    public class PolynomUnit
    {
        public double Coefitient;
        public int Pow;

        public PolynomUnit(double coef, int power)
        {
            Coefitient = coef;
            Pow = power;
        }

        public static bool operator ==(PolynomUnit a, PolynomUnit b)
        {
            return a.Coefitient == b.Coefitient && a.Pow == b.Pow;
        }

        public static bool operator !=(PolynomUnit a, PolynomUnit b)
        {
            return !(a == b);
        }
    }
}
