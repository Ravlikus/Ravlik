using System;
using System.Collections.Generic;
using System.Data.Odbc;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


// Тут должны ещё быть MS Unit тесты, но возникла проблема с подключением пространства Microsoft.VisualStudio
// (Её не видно в подключении ссылок к проекту)
// (Описание необходимых сущностей находится в Microsoft.VisualStudio.TestTools.UnitTesting)
namespace InsertNumber
{
    [TestFixture]
    class InsertNumberTests
    {
        [TestCase(new int[] {8, 15, 3, 8}, ExpectedResult = 120)]
        [TestCase(new int[] {8,15,0,0}, ExpectedResult = 9)]
        [TestCase(new int[] {15,15,0,0}, ExpectedResult = 15)]
        [TestCase(new int[] {0,0,0,0}, ExpectedResult = 0)]
        public int IsertNumberTest(int[] input)
        {
            return NumberInserter.InsertNumber(input[0], input[1], (byte) input[2], (byte) input[3]);
        }

        // Довольно непонятная конструкция, но я не знаю, как обозначить кейс,
        // когда при входных данных должо возникать исключение
        [TestCase(new int[] {64,64,3,2}, ExpectedResult = typeof(ArgumentException))] 
        public Type WrongArgumentsTest(int[] input)
        {
            try
            {
                NumberInserter.InsertNumber(input[0], input[1], (byte) input[2], (byte) input[3]);
            }
            catch (Exception e)
            {
                return e.GetType();
            }
            throw new Exception();
        }

        [TestCase(new int[] { 3,3}, ExpectedResult = 27)]
        public int CustomPowerTestTest(int[] input)
        {
            return NumberInserter.CustomPower(input[0], input[1]);
        }
    }
}
