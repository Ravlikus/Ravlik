using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace CreatingTypesSolution
{
    public static class FindNthRootSolution
    {
        /// <summary>
        /// Собственно реализация метода Ньютона.
        /// </summary>
        /// <param name="a">Число под корнем</param>
        /// <param name="n">Степень корня</param>
        /// <param name="e">Точность</param>
        /// <returns></returns>
        public static double FindNthRoot(double a, int n, double e)
        {
            if (a < 0 && n%2 == 0 ||
                n < 0 || //тут не уверен
                e <= 0) 
                throw new ArgumentException();
            var current = a;
            double prev;
            do
            {
                prev = current;
                current = ((n - 1) * current + a / (Math.Pow(current, n - 1))) / n; //Формула из википедии
            } while (Math.Abs(prev - current) > e);
            
            return Math.Round(current,(int)Math.Log(e,0.1));
        }
    }

    [TestFixture]
    public class FindNthRootTests
    {
        [TestCase(1, 5, 0.0001, ExpectedResult = 1)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.001, 3, 0.0001, ExpectedResult = 0.1)]
        [TestCase(0.04100625, 4, 0.0001, ExpectedResult = 0.45)]
        [TestCase(8, 3, 0.0001, ExpectedResult = 2)]
        [TestCase(0.0279936, 7, 0.0001, ExpectedResult = 0.6)]
        [TestCase(0.0081, 4, 0.1, ExpectedResult = 0.3)]
        [TestCase(-0.008, 3, 0.1, ExpectedResult = -0.2)]
        [TestCase(0.004241979, 9, 0.00000001, ExpectedResult = 0.545)]
        public double SimpleFinding(double a, int n, double e)
        {
            return FindNthRootSolution.FindNthRoot(a, n, e);
        }

        [TestCase(-0.01,2,0.0001, ExpectedResult = typeof(ArgumentException))]
        [TestCase(0.001, -2, 0.0001, ExpectedResult = typeof(ArgumentException))]
        [TestCase(0.001, 2, -1, ExpectedResult = typeof(ArgumentException))]
        public Type CheckExceptions(double a, int n, double e)
        {
            try
            {
                FindNthRootSolution.FindNthRoot(a, n, e);
            }
            catch (Exception ex)
            {
                return ex.GetType();
            }
            throw new Exception("Exception was not throwed");
        }
    }
}
