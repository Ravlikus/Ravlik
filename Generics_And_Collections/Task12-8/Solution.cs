using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task12_8
{
    public class Calculator
    {
        /// <summary>
        /// Посчитать значение выражения, записанного в обратной польской записи
        /// </summary>
        /// <param name="expression">выражение, записанное в обратной польской записи</param>
        /// <returns>Значение выражения</returns>
        public static int Count(string expression)
        {
            var splitedExpression = expression.Split();
            var countStack = new Stack<int>();
            for(int i = 0; i < splitedExpression.Length; i++)
            {
                if (splitedExpression[i] == " ") continue;
                else if (char.IsDigit(splitedExpression[i][0]))
                {
                    foreach(var symb in splitedExpression[i])
                    {
                        if (!char.IsDigit(symb)) throw new ArgumentException("Invalid expression string");
                    }
                    countStack.Push(int.Parse(splitedExpression[i]));
                }
                else
                {
                    if (splitedExpression[i] == "+")
                    {
                        countStack.Push(countStack.Pop() + countStack.Pop());
                    }
                    else if (splitedExpression[i] == "-")
                    {
                        countStack.Push(-countStack.Pop() + countStack.Pop());
                    }
                    else if (splitedExpression[i] == "*")
                    {
                        countStack.Push(countStack.Pop() * countStack.Pop());
                    }
                    else if (splitedExpression[i] == "/")
                    {
                        var b = countStack.Pop();
                        var a = countStack.Pop();
                        countStack.Push(a / b);
                    }
                    else throw new ArgumentException("Invalid expression string");

                }
            }
            return countStack.Pop();
        }
    }
}
