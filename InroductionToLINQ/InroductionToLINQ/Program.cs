using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace InroductionToLINQ
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Type \"Help\" for Help \\_O.O_/");
            while(true)
            {
                Console.Write(">> ");
                var input = Console.ReadLine().Split(new[] { ' '},StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    CommandInvoker.InvokeCommand(input);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

    }
}
