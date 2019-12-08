using System;

namespace Task8_3
{
    public class Polynom
    {
        public double[] PolynomUnits;

        public Polynom( params double[] values)
        {
            PolynomUnits = new double[values.Length];
            for(int i = 0; i< values.Length; i++)
            {
                PolynomUnits[i] = values[i];
            }
        }

        public double CountResult(double value)
        {
            var result = 0.0;
            for(int i = 0; i<PolynomUnits.Length; i++)
            {
                result += PolynomUnits[i] * Math.Pow(value, i + 1);
            }
            return result;
        }

        public static Polynom operator +(Polynom a, Polynom b)
        {
            Polynom result;
            if (a.PolynomUnits.Length > b.PolynomUnits.Length)
            {
                result = new Polynom(a.PolynomUnits);
                for (int i = 0; i < b.PolynomUnits.Length; i++)
                    result.PolynomUnits[i] += b.PolynomUnits[i];
            }
            else
            {
                result = new Polynom(b.PolynomUnits);
                for (int i = 0; i < a.PolynomUnits.Length; i++)
                    result.PolynomUnits[i] += a.PolynomUnits[i];
            }
            return result;
        }

        public static Polynom operator -(Polynom a, Polynom b)
        {
            Polynom result;
            if (a.PolynomUnits.Length > b.PolynomUnits.Length)
            {
                result = new Polynom(a.PolynomUnits);
                for (int i = 0; i < b.PolynomUnits.Length; i++)
                    result.PolynomUnits[i] -= b.PolynomUnits[i];
            }
            else
            {
                result = new Polynom(b.PolynomUnits);
                for (int i = 0; i < a.PolynomUnits.Length; i++)
                    result.PolynomUnits[i] -= a.PolynomUnits[i];
            }
            return result;
        }

        public static bool operator ==(Polynom a, Polynom b)
        {
            if (a is null && b is null) return true;
            if (a is null || b is null) return false;
            if (a.PolynomUnits.Length != b.PolynomUnits.Length) return false;
            for (int i = 0; i < a.PolynomUnits.Length; i++)
                if (a.PolynomUnits[i] != b.PolynomUnits[i]) return false;
            return true;
        }

        public static bool operator !=(Polynom a, Polynom b)
        {
            return !(a == b);
        }
    }
}
